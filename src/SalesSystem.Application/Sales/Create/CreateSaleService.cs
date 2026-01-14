using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Application.Common.Validation;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Sale.Models;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Application.Sales.Create;

public sealed class CreateSaleService(
    IProductRepository productRepository,
    ISaleRepository saleRepository,
    IUnitOfWork unitOfWork,
    CreateSaleValidator validator) : ICreateSaleService
{
    public async Task<int> ExecuteAsync(CreateSaleCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        var productIds = command.Items.Select(i => i.ProductId).Distinct().ToArray();
        var products = await productRepository.GetByIdsAsync(productIds);

        if (products.Count != productIds.Length)
            throw new ApplicationValidationException("Produto inválido.");

        var sale = Sale.Create(command.ClientId);

        foreach (var input in command.Items)
        {
            var product = products.First(p => p.Id == input.ProductId);

            product.DecreaseStock(input.Quantity);

            sale.AddItem(SaleItem.Create(
                product.Id,
                product.Name,
                input.Quantity,
                product.Price));
        }

        sale.EnsureHasItems();

        await unitOfWork.BeginAsync();
        try
        {
            var saleId = await saleRepository.AddAsync(sale);

            foreach (var item in sale.Items)
            {
                await saleRepository.AddItemAsync(saleId, item);
                await productRepository.UpdateAsync(
                    products.First(p => p.Id == item.ProductId));
            }

            await unitOfWork.CommitAsync();
            return saleId;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
