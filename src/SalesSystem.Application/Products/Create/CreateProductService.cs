using SalesSystem.Application.Common.Validation;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Models;
using SalesSystem.Domain.Product.Repositories;

namespace SalesSystem.Application.Products.Create;

public sealed class CreateProductService(
    IProductRepository repository,
    IUnitOfWork unitOfWork,
    CreateProductValidator validator) : ICreateProductService
{
    public async Task<int> ExecuteAsync(CreateProductCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        var product = Product.Create(
            command.Name,
            command.Description,
            command.Price,
            command.Stock
        );

        await unitOfWork.BeginAsync();
        try
        {
            var id = await repository.AddAsync(product);
            await unitOfWork.CommitAsync();
            return id;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
