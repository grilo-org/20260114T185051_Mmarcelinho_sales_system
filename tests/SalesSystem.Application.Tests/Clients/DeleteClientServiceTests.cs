using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Clients.Delete;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Sale.Repositories;

namespace SalesSystem.Application.Tests.Clients;

public class DeleteClientServiceTests
{
    [Fact]
    public async Task Should_delete_client_successfully()
    {
        var repo = Substitute.For<IClientRepository>();
        var repoSale = Substitute.For<ISaleRepository>();
        var uow = Substitute.For<IUnitOfWork>();

        repo.RemoveAsync(1).Returns(1);

        var service = new DeleteClientService(repo, repoSale, uow);

        await service.ExecuteAsync(1);

        await uow.Received(1).BeginAsync();
        await uow.Received(1).CommitAsync();
    }

    [Fact]
    public async Task Should_throw_when_client_not_found()
    {
        var repo = Substitute.For<IClientRepository>();
        var repoSale = Substitute.For<ISaleRepository>();
        var uow = Substitute.For<IUnitOfWork>();

        repo.RemoveAsync(1).Returns(0);

        var service = new DeleteClientService(repo, repoSale, uow);

        var action = async () => await service.ExecuteAsync(1);

        await action.Should().ThrowAsync<Exception>();
    }
}
