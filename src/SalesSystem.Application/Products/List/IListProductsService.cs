using SalesSystem.Domain.Product.Models;

namespace SalesSystem.Application.Products.List;

public interface IListProductsService
{
    Task<IReadOnlyList<Product>> ExecuteAsync();
}
