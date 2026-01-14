using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Products.Create;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;

namespace SalesSystem.Application.Tests.Products;

public class CreateProductServiceTests
{
    [Fact]
    public async Task Should_create_product_successfully()
    {
        var repo = Substitute.For<IProductRepository>();
        var uow = Substitute.For<IUnitOfWork>();
        var validator = new CreateProductValidator();

        var service = new CreateProductService(repo, uow, validator);

        var command = new CreateProductCommand(
            "Produto",
            "Descricao",
            10,
            5
        );

        await service.ExecuteAsync(command);

        await uow.Received(1).BeginAsync();
        await uow.Received(1).CommitAsync();
        await repo.Received(1).AddAsync(Arg.Any<Domain.Product.Models.Product>());
    }
}
