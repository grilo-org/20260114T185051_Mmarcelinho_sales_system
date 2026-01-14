using FluentAssertions;
using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Should_create_product_successfully()
    {
        var product = Product.Models.Product.Create("Produto", "Desc", 10, 5);

        product.Name.Should().Be("Produto");
        product.Stock.Should().Be(5);
    }

    [Fact]
    public void Should_not_allow_negative_stock()
    {
        var action = () =>
            Product.Models.Product.Create("Produto", "", 10, -1);

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_decrease_stock()
    {
        var product = Product.Models.Product.Create("Produto", "", 10, 5);

        product.DecreaseStock(2);

        product.Stock.Should().Be(3);
    }

    [Fact]
    public void Should_fail_when_stock_is_insufficient()
    {
        var product = Product.Models.Product.Create("Produto", "", 10, 1);

        var action = () => product.DecreaseStock(2);

        action.Should().Throw<DomainException>();
    }
}
