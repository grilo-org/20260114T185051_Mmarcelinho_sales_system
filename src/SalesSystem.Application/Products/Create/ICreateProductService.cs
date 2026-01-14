namespace SalesSystem.Application.Products.Create;

public interface ICreateProductService
{
    Task<int> ExecuteAsync(CreateProductCommand command);
}
