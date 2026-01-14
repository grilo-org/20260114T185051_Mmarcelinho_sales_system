using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Domain.Common.Exceptions;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Application.Products.Delete;

public sealed class DeleteProductService(
    IProductRepository repository,
    ISaleRepository saleRepository,
    IUnitOfWork unitOfWork) : IDeleteProductService
{
    public async Task ExecuteAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Produto inválido.");

        var hasSales = await saleRepository.ExistsForProductAsync(id);
        if (hasSales)
            throw new ApplicationValidationException(
                "Não é possível excluir o produto pois ele possui vendas associadas."
            );

        await unitOfWork.BeginAsync();
        try
        {
            var affectedRows = await repository.RemoveAsync(id);

            if (affectedRows == 0)
                throw new Exception("Produto não encontrado.");

            await unitOfWork.CommitAsync();
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
