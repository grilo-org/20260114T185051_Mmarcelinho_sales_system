using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Application.Common.Validation;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;

namespace SalesSystem.Application.Products.Update;

public sealed class UpdateProductService(
    IProductRepository repository,
    IUnitOfWork unitOfWork,
    UpdateProductValidator validator) : IUpdateProductService
{
    public async Task ExecuteAsync(UpdateProductCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        var product = await repository.GetByIdAsync(command.Id)
            ?? throw new NotFoundException("Produto não encontrado.");

        product.Update(
            command.Name,
            command.Description,
            command.Price,
            command.Stock
        );

        await unitOfWork.BeginAsync();
        try
        {
            await repository.UpdateAsync(product);
            await unitOfWork.CommitAsync();
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
