using NSubstitute;
using SalesSystem.Application.Products.Update;
using SalesSystem.Domain.Product.Models;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Application.Tests.Products;
public class UpdateProductServiceTests
{
    [Fact]
    public async Task Should_update_product_successfully()
    {
        var repo = Substitute.For<IProductRepository>();
        var uow = Substitute.For<IUnitOfWork>();
        var validator = new UpdateProductValidator();

        var product = Product.Create("Produto", "", 10, 5);
        product.Id = 1;

        repo.GetByIdAsync(1).Returns(product);

        var service = new UpdateProductService(repo, uow, validator);

        var command = new UpdateProductCommand(
            1,
            "Produto Atualizado",
            "Desc",
            15,
            10
        );

        await service.ExecuteAsync(command);

        await uow.Received(1).CommitAsync();
    }
}
