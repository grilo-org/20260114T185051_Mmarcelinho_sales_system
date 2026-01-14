namespace SalesSystem.Domain.Client.Repositories;

public interface IClientRepository
{
    Task<bool> EmailExistsAsync(string email);
    Task<Models.Client?> GetByIdAsync(int id);
    Task<IReadOnlyList<Models.Client>> GetAllAsync();
    Task<int> AddAsync(Models.Client client);
    Task UpdateAsync(Models.Client client);
    Task<int> RemoveAsync(int id);
}
