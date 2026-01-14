namespace SalesSystem.Domain.Sale.Repositories;

public interface ISaleRepository
{
    Task<int> AddAsync(Models.Sale sale);
    Task AddItemAsync(int saleId, Models.SaleItem item);
    Task<bool> ExistsForClientAsync(int clientId);
    Task<bool> ExistsForProductAsync(int productId);
}
