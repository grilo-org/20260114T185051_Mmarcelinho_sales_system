using Dapper;
using SalesSystem.Domain.Client.Repositories;
using static SalesSystem.Infrastructure.Persistence.Client.ClientQueries;

namespace SalesSystem.Infrastructure.Persistence.Client;

public sealed class ClientRepository(DbSession session) : IClientRepository
{
    public async Task<bool> EmailExistsAsync(string email)
    {
        var qm = EmailExists(email);

        var result = await session.Connection.ExecuteScalarAsync<int?>(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );

        return result.HasValue;
    }

    public async Task<int> AddAsync(Domain.Client.Models.Client client)
    {
        var qm = Insert(
            client.Name,
            client.Email.Value,
            client.Phone
        );

        var id = await session.Connection.ExecuteScalarAsync<int>(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );

        client.Id = id;
        return id;
    }

    public async Task UpdateAsync(Domain.Client.Models.Client client)
    {
        var qm = Update(
            client.Id,
            client.Name,
            client.Email.Value,
            client.Phone
        );

        await session.Connection.ExecuteAsync(
            qm.Query,
            qm.Parameters,
            session.Transaction
        );
    }

    public async Task<int> RemoveAsync(int id)
    {
        var query = Delete(id);

        var affectedRows = await session.Connection.ExecuteAsync(
            query.Query,
            query.Parameters,
            session.Transaction
        );

        return affectedRows;
    }

    public async Task<Domain.Client.Models.Client?> GetByIdAsync(int id)
    {
        var query = GetById(id);

        var row = await session.Connection.QuerySingleOrDefaultAsync<ClientRow>(
            query.Query,
            query.Parameters
        );

        if (row is null)
            return null;

        var client = Domain.Client.Models.Client.Create(
        row.Name,
        row.Email,
        row.Phone
    );

        client.Id = row.Id;

        return client;
    }

    public async Task<IReadOnlyList<Domain.Client.Models.Client>> GetAllAsync()
    {
        var query = GetAll();

        var rows = await session.Connection.QueryAsync<ClientRow>(
            query.Query,
            query.Parameters
        );

        return [.. rows
        .Select(row =>
        {
            var client = Domain.Client.Models.Client.Create(
                row.Name,
                row.Email,
                row.Phone
            );

            client.Id = row.Id;
            return client;
        })];
    }
}
