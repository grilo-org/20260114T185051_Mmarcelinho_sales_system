namespace SalesSystem.Application.Clients.Delete;

public interface IDeleteClientService
{
    Task ExecuteAsync(int id);
}
