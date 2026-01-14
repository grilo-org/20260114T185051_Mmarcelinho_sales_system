namespace SalesSystem.Application.Products.Update;

public interface IUpdateProductService
{
    Task ExecuteAsync(UpdateProductCommand command);
}
