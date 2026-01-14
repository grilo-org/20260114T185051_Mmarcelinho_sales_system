namespace SalesSystem.Application.Products.Update;

public sealed record UpdateProductCommand(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock
);
