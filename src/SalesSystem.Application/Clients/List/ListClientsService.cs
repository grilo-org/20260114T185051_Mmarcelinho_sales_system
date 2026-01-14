using SalesSystem.Domain.Client.Models;
using SalesSystem.Domain.Client.Repositories;

namespace SalesSystem.Application.Clients.List;

public sealed class ListClientsService(IClientRepository repository) : IListClientsService
{
    public async Task<IReadOnlyList<Client>> ExecuteAsync() => await repository.GetAllAsync();
}
