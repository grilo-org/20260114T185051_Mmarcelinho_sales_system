using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Application.Common.Validation;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;

namespace SalesSystem.Application.Clients.Update;

public sealed class UpdateClientService(
    IClientRepository repository,
    IUnitOfWork unitOfWork,
    UpdateClientValidator validator) : IUpdateClientService
{
    public async Task ExecuteAsync(UpdateClientCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        var client = await repository.GetByIdAsync(command.Id)
            ?? throw new NotFoundException("Cliente não encontrado.");

        client.Update(command.Name, command.Email, command.Phone);

        await unitOfWork.BeginAsync();
        try
        {
            await repository.UpdateAsync(client);
            await unitOfWork.CommitAsync();
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
