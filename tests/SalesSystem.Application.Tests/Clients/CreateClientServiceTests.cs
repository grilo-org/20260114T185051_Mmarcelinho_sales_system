
using FluentAssertions;
using NSubstitute;
using SalesSystem.Application.Clients.Create;
using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Application.Tests.Clients;

public class CreateClientServiceTests
{
    private readonly IClientRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateClientValidator _validator;
    private readonly CreateClientService _service;

    public CreateClientServiceTests()
    {
        _repository = Substitute.For<IClientRepository>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _validator = new CreateClientValidator();

        _service = new CreateClientService(
            _repository,
            _unitOfWork,
            _validator);
    }

    [Fact]
    public async Task Should_create_client_successfully()
    {
        _repository.EmailExistsAsync(Arg.Any<string>())
            .Returns(false);

        var command = new CreateClientCommand(
            "Marcelo",
            "marcelo@email.com",
            "11999999999"
        );

        await _service.ExecuteAsync(command);

        await _unitOfWork.Received(1).BeginAsync();
        await _unitOfWork.Received(1).CommitAsync();
        await _repository.Received(1).AddAsync(Arg.Any<SalesSystem.Domain.Client.Models.Client>());
    }

    [Fact]
    public async Task Should_throw_when_email_already_exists()
    {
        _repository.EmailExistsAsync(Arg.Any<string>())
            .Returns(true);

        var command = new CreateClientCommand(
            "Marcelo",
            "marcelo@email.com",
            "11999999999"
        );

        var action = async () => await _service.ExecuteAsync(command);

        await action.Should()
            .ThrowAsync<ApplicationValidationException>()
            .WithMessage("*E-mail*");
    }
}
