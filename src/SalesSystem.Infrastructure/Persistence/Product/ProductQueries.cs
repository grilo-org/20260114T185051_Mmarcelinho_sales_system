using SalesSystem.Infrastructure.Persistence.Common;

namespace SalesSystem.Infrastructure.Persistence.Product;

public static class ProductQueries
{
    public static QueryModel GetAll() =>
        new("""
            SELECT
                id          AS "Id",
                name        AS "Name",
                description AS "Description",
                price       AS "Price",
                stock       AS "Stock"
            FROM products
            ORDER BY name;
        """, new { });

    public static QueryModel GetById(int id) =>
        new("""
            SELECT
                id          AS "Id",
                name        AS "Name",
                description AS "Description",
                price       AS "Price",
                stock       AS "Stock"
            FROM products
            WHERE id = @Id;
        """, new { Id = id });

    public static QueryModel GetByIds(IEnumerable<int> ids) =>
        new("""
            SELECT
                id          AS "Id",
                name        AS "Name",
                description AS "Description",
                price       AS "Price",
                stock       AS "Stock"
            FROM products
            WHERE id = ANY(@Ids);
        """, new { Ids = ids.ToArray() });

    public static QueryModel Insert(string name, string description, decimal price, int stock) =>
        new("""
            INSERT INTO products (name, description, price, stock)
            VALUES (@Name,@Description,@Price,@Stock)
            RETURNING id;
        """, new { Name = name, Description = description, Price = price, Stock = stock });

    public static QueryModel Update(int id, string name, string description, decimal price, int stock) =>
        new("""
            UPDATE products
            SET name=@Name,
                description=@Description,
                price=@Price,
                stock=@Stock
            WHERE id=@Id;
        """, new { Id = id, Name = name, Description = description, Price = price, Stock = stock });

    public static QueryModel Delete(int id) =>
        new("DELETE FROM products WHERE id=@Id;", new { Id = id });
}
