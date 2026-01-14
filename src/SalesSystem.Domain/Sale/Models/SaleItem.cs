using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Sale.Models;

public sealed class SaleItem
{
    private SaleItem(int productId, string productName, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => Quantity * UnitPrice;

    public static SaleItem Create(int productId, string productName, int quantity, decimal unitPrice)
    {
        if (productId <= 0)
            throw new DomainException("Produto inválido.");

        if (string.IsNullOrWhiteSpace(productName))
            throw new DomainException("Nome do produto inválido.");

        if (quantity <= 0)
            throw new DomainException("Quantidade inválida.");

        if (unitPrice <= 0)
            throw new DomainException("Preço inválido.");

        return new SaleItem(
            productId,
            productName.Trim(),
            quantity,
            unitPrice
        );
    }
}
