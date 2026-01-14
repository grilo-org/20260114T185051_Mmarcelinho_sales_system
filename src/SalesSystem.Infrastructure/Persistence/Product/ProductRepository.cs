using Dapper;
using SalesSystem.Domain.Product.Repositories;

namespace SalesSystem.Infrastructure.Persistence.Product;

public sealed class ProductRepository(DbSession session) : IProductRepository
{
    public async Task<Domain.Product.Models.Product?> GetByIdAsync(int id)
    {
        var qm = ProductQueries.GetById(id);

        return await session.Connection.QuerySingleOrDefaultAsync<Domain.Product.Models.Product>(
            qm.Query,
            qm.Parameters
        );
    }

    public async Task<IReadOnlyList<Domain.Product.Models.Product>> GetAllAsync()
    {
        var qm = ProductQueries.GetAll();

        var list = await session.Connection.QueryAsync<Domain.Product.Models.Product>(
            qm.Query,
            qm.Parameters
        );

        return [.. list];
    }

    public async Task<IReadOnlyList<Domain.Product.Models.Product>> GetByIdsAsync(IEnumerable<int> ids)
    {
        var idsArray = ids?.ToArray() ?? [];

        if (idsArray.Length == 0)
            return [];

        var qm = ProductQueries.GetByIds(idsArray);

        var list = await session.Connection.QueryAsync<Domain.Product.Models.Product>(
            qm.Query,
            qm.Parameters
        );

        return [.. list];
    }

    public async Task<int> AddAsync(Domain.Product.Models.Product product)
    {
        var qm = ProductQueries.Insert(
            product.Name,
            product.Description,
            product.Price,
            product.Stock
        );

        var id = await session.Connection.ExecuteScalarAsync<int>(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );

        product.Id = id;
        return id;
    }

    public async Task UpdateAsync(Domain.Product.Models.Product product)
    {
        var qm = ProductQueries.Update(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock
        );

        await session.Connection.ExecuteAsync(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );
    }

    public async Task<int> RemoveAsync(int id)
    {
        var query = ProductQueries.Delete(id);

        var affectedRows = await session.Connection.ExecuteAsync(
            query.Query,
            query.Parameters,
            session.Transaction
        );

        return affectedRows;
    }
}
