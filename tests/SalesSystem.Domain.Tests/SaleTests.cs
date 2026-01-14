using FluentAssertions;
using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Tests;

public class SaleTests
{
    [Fact]
    public void Should_add_items_and_calculate_total()
    {
        var sale = Sale.Models.Sale.Create(1);

        sale.AddItem(Sale.Models.SaleItem.Create(1, "Produto A", 2, 10));
        sale.AddItem(Sale.Models.SaleItem.Create(2, "Produto B", 1, 5));

        sale.Total.Should().Be(25);
    }

    [Fact]
    public void Should_not_allow_duplicate_products()
    {
        var sale = Sale.Models.Sale.Create(1);
        var item = Sale.Models.SaleItem.Create(1, "Produto", 1, 10);

        sale.AddItem(item);

        var action = () => sale.AddItem(item);

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_fail_when_sale_has_no_items()
    {
        var sale = Sale.Models.Sale.Create(1);

        var action = () => sale.EnsureHasItems();

        action.Should().Throw<DomainException>();
    }
}
