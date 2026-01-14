namespace SalesSystem.Application.Clients.Update;

public interface IUpdateClientService
{
    Task ExecuteAsync(UpdateClientCommand command);
}
