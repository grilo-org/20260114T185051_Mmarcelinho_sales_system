using SalesSystem.Domain.Client.ValueObjects;
using SalesSystem.Domain.Common.Exceptions;

namespace SalesSystem.Domain.Client.Models;

public sealed class Client
{
    internal Client() { }

    private Client(string name, Email email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    private Client(int id, string name, Email email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Email Email { get; set; } = default!;
    public string Phone { get; set; } = string.Empty;

    public static Client Create(string name, string email, string phone)
    {
        Validate(name, phone);

        return new(
            name.Trim(),
            new Email(email),
            phone.Trim()
        );
    }

    public void Update(string name, string email, string phone)
    {
        Validate(name, phone);

        Name = name.Trim();
        Email = new Email(email);
        Phone = phone.Trim();
    }

    private static void Validate(string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("O nome do cliente é obrigatório.");

        if (string.IsNullOrWhiteSpace(phone))
            throw new DomainException("O telefone do cliente é obrigatório.");
    }
}
