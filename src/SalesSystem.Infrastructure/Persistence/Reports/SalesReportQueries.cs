using SalesSystem.Infrastructure.Persistence.Common;

namespace SalesSystem.Infrastructure.Persistence.Reports;

public static class SalesReportQueries
{
    public static QueryModel ByPeriod(DateTime start, DateTime end) =>
        new("""
            SELECT
                c.id            AS "ClientId",
                c.name          AS "ClientName",
                s.id            AS "SaleId",
                s.sold_at       AS "SoldAt",
                si.product_name AS "ProductName",
                si.quantity     AS "Quantity",
                si.unit_price   AS "UnitPrice",
                si.line_total   AS "LineTotal"
            FROM sales s
            INNER JOIN clients c     ON c.id = s.client_id
            INNER JOIN sale_items si ON si.sale_id = s.id
            WHERE s.sold_at BETWEEN @Start AND @End
            ORDER BY c.name, s.sold_at;
        """,
        new
        {
            Start = start,
            End = end
        });
}
