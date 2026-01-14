using System.Data;

namespace SalesSystem.Application.Reports;

public interface ISalesReportService
{
    Task<DataTable> GetByPeriodAsync(
        DateTime start,
        DateTime end);
}
