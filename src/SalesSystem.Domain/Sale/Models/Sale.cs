using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Sale.Models;

public sealed class Sale
{
    internal Sale() { }

    private Sale(int clientId)
    {
        ClientId = clientId;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime CreatedAt { get; set; }
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();
    public decimal Total => _items.Sum(i => i.Total);

    private readonly List<SaleItem> _items = [];

    public static Sale Create(int clientId)
    {
        if (clientId <= 0)
            throw new DomainException("Cliente inválido.");

        return new Sale(clientId);
    }

    public void AddItem(SaleItem item)
    {
        if (_items.Any(i => i.ProductId == item.ProductId))
            throw new DomainException("Produto já adicionado à venda.");

        _items.Add(item);
    }

    public void RemoveItem(int productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId) ?? throw new DomainException("Item não encontrado.");
        _items.Remove(item);
    }

    public void EnsureHasItems()
    {
        if (_items.Count == 0)
            throw new DomainException("A venda deve conter ao menos um item.");
    }
}
