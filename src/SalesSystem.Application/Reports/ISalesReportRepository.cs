using System.Data;

namespace SalesSystem.Application.Reports;

public interface ISalesReportRepository
{
    Task<DataTable> GetSalesByPeriodAsync(
        DateTime start,
        DateTime end);
}
