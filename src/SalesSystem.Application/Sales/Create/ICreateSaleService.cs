namespace SalesSystem.Application.Sales.Create;

public interface ICreateSaleService
{
    Task<int> ExecuteAsync(CreateSaleCommand command);
}
