using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Sales.Create;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Models;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Application.Tests.Sales;

public class CreateSaleServiceTests
{
    [Fact]
    public async Task Should_create_sale_and_update_stock()
    {
        var productRepo = Substitute.For<IProductRepository>();
        var saleRepo = Substitute.For<ISaleRepository>();
        var uow = Substitute.For<IUnitOfWork>();
        var validator = new CreateSaleValidator();
        
        var product = Product.Create("Produto", "", 10, 10);
        product.Id = 1;

        productRepo.GetByIdsAsync(Arg.Any<IEnumerable<int>>())
            .Returns([product]);

        var service = new CreateSaleService(
            productRepo,
            saleRepo,
            uow,
            validator
        );

        var command = new CreateSaleCommand(
            1,
            [
                new SaleItemInput(1, 2)
            ]
        );

        await service.ExecuteAsync(command);

        product.Stock.Should().Be(8);
        await uow.Received(1).CommitAsync();
    }
}
