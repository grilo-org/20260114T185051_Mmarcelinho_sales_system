using SalesSystem.Infrastructure.Persistence.Common;

namespace SalesSystem.Infrastructure.Persistence.Sale;

public static class SaleQueries
{
    public static QueryModel InsertSale(int clientId, DateTime createdAt, decimal total) =>
        new("""
            INSERT INTO sales (client_id, sold_at, total)
            VALUES (@ClientId,@CreatedAt,@Total)
            RETURNING id;
        """, new { ClientId = clientId, CreatedAt = createdAt, Total = total });

    public static QueryModel InsertItem(
        int saleId,
        int productId,
        string productName,
        int quantity,
        decimal unitPrice,
        decimal lineTotal) =>
        new("""
            INSERT INTO sale_items
            (sale_id, product_id, product_name, quantity, unit_price, line_total)
            VALUES (@SaleId,@ProductId,@ProductName,@Quantity,@UnitPrice,@LineTotal);
        """,
        new
        {
            SaleId = saleId,
            ProductId = productId,
            ProductName = productName,
            Quantity = quantity,
            UnitPrice = unitPrice,
            LineTotal = lineTotal
        });

    public static QueryModel ExistsForClient(int clientId) =>
        new("""
            SELECT 1
            FROM sales
            WHERE client_id = @ClientId
            LIMIT 1;
        """, new { ClientId = clientId });

    public static QueryModel ExistsForProduct(int productId) =>
        new("""
            SELECT 1
            FROM sale_items
            WHERE product_id = @ProductId
            LIMIT 1;
        """, new { ProductId = productId });
}