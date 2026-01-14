using Dapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SalesSystem.Application.Sales.Create;
using SalesSystem.Integration.Tests.Fixtures;

namespace SalesSystem.Integration.Tests;

public sealed class SaleRollbackIntegrationTests : IClassFixture<PostgreSqlFixture>
{
    private readonly PostgreSqlFixture _db;

    public SaleRollbackIntegrationTests(PostgreSqlFixture db) => _db = db;

    [Fact]
    public async Task Should_Rollback_Sale_When_Any_Product_Has_Insufficient_Stock()
    {
        await _db.ResetDatabaseAsync();

        await using var conn = new NpgsqlConnection(_db.ConnectionString);
        await conn.OpenAsync();

        var clientId = await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO clients (name, email, phone)
            VALUES ('Cliente 1', 'c1@email.com', '111')
            RETURNING id;
        ");

        var productId = await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO products (name, description, price, stock)
            VALUES ('Produto A', 'Desc', 10.00, 1)
            RETURNING id;
        ");

        using var sp = TestHost.Build(_db.ConnectionString);
        using var scope = sp.CreateScope();

        var service = scope.ServiceProvider.GetRequiredService<ICreateSaleService>();

        var cmd = new CreateSaleCommand(
            clientId,
            new[]
            {
                new SaleItemInput(productId, 2)
            });

        var action = async () => await service.ExecuteAsync(cmd);

        await action.Should().ThrowAsync<Exception>();

        var salesCount = await conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM sales;");
        salesCount.Should().Be(0);

        var itemsCount = await conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM sale_items;");
        itemsCount.Should().Be(0);

        var stock = await conn.ExecuteScalarAsync<int>("SELECT stock FROM products WHERE id=@Id;", new { Id = productId });
        stock.Should().Be(1);
    }
}
