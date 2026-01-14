using System.Data;
using Dapper;
using SalesSystem.Application.Reports;

namespace SalesSystem.Infrastructure.Persistence.Reports;

public sealed class SalesReportRepository(DbSession session) : ISalesReportRepository
{
    public async Task<DataTable> GetSalesByPeriodAsync(
        DateTime start,
        DateTime end)
    {
        var query = SalesReportQueries.ByPeriod(start, end);

        using var reader = await session.Connection.ExecuteReaderAsync(
            query.Query,
            query.Parameters,
            session.Transaction);

        var table = new DataTable();
        table.Load(reader);

        return table;
    }
}
