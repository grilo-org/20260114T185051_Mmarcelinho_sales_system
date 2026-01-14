using Dapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SalesSystem.Application.Products.Delete;
using SalesSystem.Integration.Tests.Fixtures;

namespace SalesSystem.Integration.Tests;

public sealed class DeleteRulesIntegrationTests(PostgreSqlFixture db) : IClassFixture<PostgreSqlFixture>
{
    [Fact]
    public async Task Should_Not_Delete_Product_When_Product_Has_Sales()
    {
        await db.ResetDatabaseAsync();

        await using var conn = new NpgsqlConnection(db.ConnectionString);
        await conn.OpenAsync();

        var clientId = await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO clients (name, email, phone)
            VALUES ('Cliente 1', 'c1@email.com', '111')
            RETURNING id;
        ");

        var productId = await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO products (name, description, price, stock)
            VALUES ('Produto A', 'Desc', 10.00, 10)
            RETURNING id;
        ");

        var saleId = await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO sales (client_id, total)
            VALUES (@ClientId, 20.00)
            RETURNING id;
        ", new { ClientId = clientId });

        await conn.ExecuteAsync(@"
            INSERT INTO sale_items (sale_id, product_id, product_name, quantity, unit_price, line_total)
            VALUES (@SaleId, @ProductId, 'Produto A', 2, 10.00, 20.00);
        ", new { SaleId = saleId, ProductId = productId });

        using var sp = TestHost.Build(db.ConnectionString);
        using var scope = sp.CreateScope();

        var service = scope.ServiceProvider.GetRequiredService<IDeleteProductService>();

        var action = async () => await service.ExecuteAsync(productId);

        await action.Should().ThrowAsync<Exception>();

        var exists = await conn.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM products WHERE id=@Id;",
            new { Id = productId });

        exists.Should().Be(1);
    }
}
