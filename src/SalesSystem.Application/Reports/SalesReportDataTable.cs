using System.Data;

namespace SalesSystem.Application.Reports;

public static class SalesReportDataTable
{
    public static DataTable Create()
    {
        var table = new DataTable("SalesDataSet");

        table.Columns.Add("ClientId", typeof(int));
        table.Columns.Add("ClientName", typeof(string));
        table.Columns.Add("SaleId", typeof(int));
        table.Columns.Add("SoldAt", typeof(DateTime));
        table.Columns.Add("ProductName", typeof(string));
        table.Columns.Add("Quantity", typeof(int));
        table.Columns.Add("UnitPrice", typeof(decimal));
        table.Columns.Add("LineTotal", typeof(decimal));

        return table;
    }

    public static void AddRow(
        DataTable table,
        int clientId,
        string clientName,
        int saleId,
        DateTime soldAt,
        string productName,
        int quantity,
        decimal unitPrice,
        decimal lineTotal)
    {
        table.Rows.Add(
            clientId,
            clientName,
            saleId,
            soldAt,
            productName,
            quantity,
            unitPrice,
            lineTotal
        );
    }
}
