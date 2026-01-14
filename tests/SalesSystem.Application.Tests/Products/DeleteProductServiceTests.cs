using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Products.Delete;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Product.Repositories;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Application.Tests.Products;

public class DeleteProductServiceTests
{
    [Fact]
    public async Task Should_throw_when_product_has_sales()
    {
        var repo = Substitute.For<IProductRepository>();
        var repoSale = Substitute.For<ISaleRepository>();
        var uow = Substitute.For<IUnitOfWork>();

        repoSale.ExistsForProductAsync(1).Returns(true);

        var service = new DeleteProductService(repo, repoSale, uow);

        var action = async () => await service.ExecuteAsync(1);

        await action.Should().ThrowAsync<Exception>();
    }
}
