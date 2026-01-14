namespace SalesSystem.Application.Clients.Create;

public interface ICreateClientService
{
    Task<int> ExecuteAsync(CreateClientCommand command);
}