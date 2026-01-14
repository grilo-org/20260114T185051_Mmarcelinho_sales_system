using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Application.Common.Validation;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Application.Clients.Create;


public sealed class CreateClientService(
    IClientRepository repository,
    IUnitOfWork unitOfWork,
    CreateClientValidator createValidator) : ICreateClientService
{
    public async Task<int> ExecuteAsync(CreateClientCommand command)
    {
        await createValidator.ValidateAndThrowAsync(command);

        if (await repository.EmailExistsAsync(command.Email))
            throw new ApplicationValidationException("E-mail já cadastrado.");

        var client = Domain.Client.Models.Client.Create(
            command.Name,
            command.Email,
            command.Phone
        );

        await unitOfWork.BeginAsync();
        try
        {
            var id = await repository.AddAsync(client);
            await unitOfWork.CommitAsync();
            return id;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}