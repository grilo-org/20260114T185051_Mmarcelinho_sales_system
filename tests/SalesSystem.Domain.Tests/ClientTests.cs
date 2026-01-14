using FluentAssertions;
using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Tests;

public class ClientTests
{
    [Fact]
    public void Should_create_client()
    {
        var client = Client.Models.Client.Create("Marcelo", "teste@email.com", "11999999999");

        client.Name.Should().Be("Marcelo");
    }

    [Fact]
    public void Should_fail_when_email_is_invalid()
    {
        var action = () =>
            Client.Models.Client.Create("Marcelo", "email-invalido", "11999999999");

        action.Should().Throw<DomainException>();
    }
}
