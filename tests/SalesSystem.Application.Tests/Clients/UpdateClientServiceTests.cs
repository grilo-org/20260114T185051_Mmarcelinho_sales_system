using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Clients.Update;
using SalesSystem.Domain.Client.Models;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Application.Tests.Clients;

public class UpdateClientServiceTests
{
    [Fact]
    public async Task Should_update_client_successfully()
    {
        var repo = Substitute.For<IClientRepository>();
        var uow = Substitute.For<IUnitOfWork>();
        var validator = new UpdateClientValidator();

        var client = Client.Create("Marcelo", "old@email.com", "119");
        client.Id = 1;

        repo.GetByIdAsync(1).Returns(client);

        var service = new UpdateClientService(repo, uow, validator);

        var command = new UpdateClientCommand(
            1,
            "Marcelo Atualizado",
            "new@email.com",
            "119"
        );

        await service.ExecuteAsync(command);

        await uow.Received(1).BeginAsync();
        await uow.Received(1).CommitAsync();
        await repo.Received(1).UpdateAsync(client);
    }

    [Fact]
    public async Task Should_throw_when_client_not_found()
    {
        var repo = Substitute.For<IClientRepository>();
        var uow = Substitute.For<IUnitOfWork>();
        var validator = new UpdateClientValidator();

        repo.GetByIdAsync(Arg.Any<int>())
            .Returns((Client?)null);

        var service = new UpdateClientService(repo, uow, validator);

        var command = new UpdateClientCommand(
            1,
            "Nome",
            "email@email.com",
            "119"
        );

        var action = async () => await service.ExecuteAsync(command);

        await action.Should().ThrowAsync<Exception>();
    }
}
