namespace SalesSystem.Application.Sales.Create;

public sealed record SaleItemInput(
    int ProductId,
    int Quantity
);

public sealed record CreateSaleCommand(
    int ClientId,
    IReadOnlyCollection<SaleItemInput> Items
);
