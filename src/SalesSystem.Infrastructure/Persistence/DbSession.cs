using Npgsql;
using System.Data;

namespace SalesSystem.Infrastructure.Persistence;

public sealed class DbSession : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction? Transaction { get; set; }

    public DbSession(string connectionString)
    {
        Connection = new NpgsqlConnection(connectionString);
        Connection.Open();
    }

    public void Dispose()
    {
        Transaction?.Dispose();
        Connection.Dispose();
    }
}