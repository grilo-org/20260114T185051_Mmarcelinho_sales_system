using System.Data;

namespace SalesSystem.Application.Reports;

public sealed class SalesReportService(ISalesReportRepository repository) : ISalesReportService
{
    public async Task<DataTable> GetByPeriodAsync(DateTime start, DateTime end)
    {
        var rawData = await repository.GetSalesByPeriodAsync(start, end);

        var table = SalesReportDataTable.Create();

        foreach (DataRow row in rawData.Rows)
        {
            SalesReportDataTable.AddRow(
                table,
                (int)row["ClientId"],
                row["ClientName"].ToString()!,
                (int)row["SaleId"],
                (DateTime)row["SoldAt"],
                row["ProductName"].ToString()!,
                (int)row["Quantity"],
                (decimal)row["UnitPrice"],
                (decimal)row["LineTotal"]
            );
        }

        return table;
    }
}
