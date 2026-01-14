namespace SalesSystem.Application.Clients.Create;

public sealed record CreateClientCommand(
    string Name,
    string Email,
    string Phone
);

