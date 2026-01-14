using SalesSystem.Domain.Client.Models;

namespace SalesSystem.Application.Clients.List;

public interface IListClientsService
{
    Task<IReadOnlyList<Client>> ExecuteAsync();
}
