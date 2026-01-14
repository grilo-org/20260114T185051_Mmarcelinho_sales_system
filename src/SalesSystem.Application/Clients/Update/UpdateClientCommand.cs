namespace SalesSystem.Application.Clients.Update;

public sealed record UpdateClientCommand(
    int Id,
    string Name,
    string Email,
    string Phone
);
