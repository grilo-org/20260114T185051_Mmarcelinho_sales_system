using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Infrastructure.Persistence;

public sealed class UnitOfWork(DbSession session) : IUnitOfWork
{
    public Task BeginAsync()
    {
        session.Transaction = session.Connection.BeginTransaction();
        return Task.CompletedTask;
    }

    public Task CommitAsync()
    {
        session.Transaction?.Commit();
        session.Transaction?.Dispose();
        session.Transaction = null;
        return Task.CompletedTask;
    }

    public Task RollbackAsync()
    {
        session.Transaction?.Rollback();
        session.Transaction?.Dispose();
        session.Transaction = null;
        return Task.CompletedTask;
    }
}