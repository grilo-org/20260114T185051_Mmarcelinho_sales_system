namespace SalesSystem.Domain.Product.Repositories;

public interface IProductRepository
{
    Task<Models.Product?> GetByIdAsync(int id);

    Task<IReadOnlyList<Models.Product>> GetAllAsync();

    Task<IReadOnlyList<Models.Product>> GetByIdsAsync(IEnumerable<int> ids);
    Task<int> AddAsync(Models.Product product);

    Task UpdateAsync(Models.Product product);

    Task<int> RemoveAsync(int id);
}
