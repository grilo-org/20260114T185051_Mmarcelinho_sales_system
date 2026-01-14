using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Product.Models;

public sealed class Product
{
    internal Product() { }

    private Product(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public static Product Create(string name, string description, decimal price, int stock)
    {
        Validate(name, price, stock);

        return new(
            name.Trim(),
            description?.Trim() ?? string.Empty,
            price,
            stock
        );
    }

    public void Update(string name, string description, decimal price, int stock)
    {
        Validate(name, price, stock);

        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        Price = price;
        Stock = stock;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantidade inválida.");

        if (Stock < quantity)
            throw new DomainException("Estoque insuficiente.");

        Stock -= quantity;
    }

    private static void Validate(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("O nome do produto é obrigatório.");

        if (price <= 0)
            throw new DomainException("O preço deve ser maior que zero.");

        if (stock < 0)
            throw new DomainException("O estoque não pode ser negativo.");
    }
}
