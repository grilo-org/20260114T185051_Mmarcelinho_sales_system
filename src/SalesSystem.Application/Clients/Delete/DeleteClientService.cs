using SalesSystem.Application.Common.Exceptions;
using SalesSystem.Domain.Client.Repositories;
using SalesSystem.Domain.Common.Interfaces;
using SalesSystem.Domain.Sale.Repositories;
namespace SalesSystem.Application.Clients.Delete;

public sealed class DeleteClientService(
    IClientRepository repository,
    ISaleRepository saleRepository,
    IUnitOfWork unitOfWork) : IDeleteClientService
{
    public async Task ExecuteAsync(int id)
    {
        if (id <= 0)
            throw new ApplicationValidationException("Cliente inválido.");

        var hasSales = await saleRepository.ExistsForClientAsync(id);
        if (hasSales)
            throw new ApplicationValidationException("Não é possível excluir o cliente pois ele possui vendas associadas.");

        await unitOfWork.BeginAsync();
        try
        {
            var affectedRows = await repository.RemoveAsync(id);

            if (affectedRows == 0)
                throw new NotFoundException("Cliente não encontrado.");

            await unitOfWork.CommitAsync();
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
