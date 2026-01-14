using SalesSystem.Infrastructure.Persistence.Common;

namespace SalesSystem.Infrastructure.Persistence.Client;

public static class ClientQueries
{
    public static QueryModel GetAll() =>
        new("""
            SELECT
                id    AS "Id",
                name  AS "Name",
                email AS "Email",
                phone AS "Phone"
            FROM clients
            ORDER BY name;
        """, new { });

    public static QueryModel GetById(int id) =>
        new("""
            SELECT
                id    AS "Id",
                name  AS "Name",
                email AS "Email",
                phone AS "Phone"
            FROM clients
            WHERE id = @Id;
        """, new { Id = id });

    public static QueryModel EmailExists(string email) =>
        new("""
            SELECT 1
            FROM clients
            WHERE email = @Email
            LIMIT 1;
        """, new { Email = email });

    public static QueryModel Insert(string name, string email, string phone) =>
        new("""
            INSERT INTO clients (name, email, phone)
            VALUES (@Name, @Email, @Phone)
            RETURNING id;
        """, new { Name = name, Email = email, Phone = phone });

    public static QueryModel Update(int id, string name, string email, string phone) =>
        new("""
            UPDATE clients
            SET name=@Name,
                email=@Email,
                phone=@Phone
            WHERE id=@Id;
        """, new { Id = id, Name = name, Email = email, Phone = phone });

    public static QueryModel Delete(int id) =>
        new("DELETE FROM clients WHERE id=@Id;", new { Id = id });

    internal sealed record ClientRow(
    int Id,
    string Name,
    string Email,
    string Phone
);
}
