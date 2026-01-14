namespace SalesSystem.Application.Products.Delete;

public interface IDeleteProductService
{
    Task ExecuteAsync(int id);
}
