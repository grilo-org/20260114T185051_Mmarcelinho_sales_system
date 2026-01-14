using SalesSystem.Domain.Product.Models;
using SalesSystem.Domain.Product.Repositories;

namespace SalesSystem.Application.Products.List;

public sealed class ListProductsService(IProductRepository repository) : IListProductsService
{
    public async Task<IReadOnlyList<Product>> ExecuteAsync() => await repository.GetAllAsync();
}