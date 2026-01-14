using Dapper;
using SalesSystem.Domain.Sale.Models;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Infrastructure.Persistence.Sale;

public sealed class SaleRepository(DbSession session) : ISaleRepository
{
    public async Task<int> AddAsync(Domain.Sale.Models.Sale sale)
    {
        var qm = SaleQueries.InsertSale(
            sale.ClientId,
            sale.CreatedAt,
            sale.Total
        );

        var saleId = await session.Connection.ExecuteScalarAsync<int>(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );

        sale.Id = saleId;
        return saleId;
    }

    public async Task AddItemAsync(int saleId, SaleItem item)
    {
        var qm = SaleQueries.InsertItem(
            saleId,
            item.ProductId,
            item.ProductName,
            item.Quantity,
            item.UnitPrice,
            item.Total
        );

        await session.Connection.ExecuteAsync(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );
    }

    public async Task<bool> ExistsForClientAsync(int clientId)
    {
        var query = SaleQueries.ExistsForClient(clientId);

        var result = await session.Connection.ExecuteScalarAsync<int?>(
            query.Query,
            query.Parameters
        );

        return result.HasValue;
    }

    public async Task<bool> ExistsForProductAsync(int productId)
    {
        var query = SaleQueries.ExistsForProduct(productId);

        var result = await session.Connection.ExecuteScalarAsync<int?>(
            query.Query,
            query.Parameters
        );

        return result.HasValue;
    }
}
