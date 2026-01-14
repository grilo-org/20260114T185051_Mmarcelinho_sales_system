namespace SalesSystem.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}