using Dapper;
using Npgsql;
using Testcontainers.PostgreSql;

namespace SalesSystem.Integration.Tests.Fixtures;

public sealed class PostgreSqlFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container;

    public string ConnectionString => _container.GetConnectionString();

    public PostgreSqlFixture()
    {
        _container = new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .WithDatabase("sales_test")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();

        await using var conn = new NpgsqlConnection(ConnectionString);
        await conn.OpenAsync();

        await conn.ExecuteAsync(SchemaSql);
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }

    public async Task ResetDatabaseAsync()
    {
        await using var conn = new NpgsqlConnection(ConnectionString);
        await conn.OpenAsync();

        await conn.ExecuteAsync("""
            TRUNCATE TABLE sale_items RESTART IDENTITY CASCADE;
            TRUNCATE TABLE sales RESTART IDENTITY CASCADE;
            TRUNCATE TABLE products RESTART IDENTITY CASCADE;
            TRUNCATE TABLE clients RESTART IDENTITY CASCADE;
        """);
    }

    private const string SchemaSql = """
        CREATE TABLE IF NOT EXISTS clients (
            id          SERIAL PRIMARY KEY,
            name        VARCHAR(200) NOT NULL,
            email       VARCHAR(200) NOT NULL,
            phone       VARCHAR(30)  NOT NULL,
            created_at  TIMESTAMPTZ  NOT NULL DEFAULT NOW()
        );

        CREATE UNIQUE INDEX IF NOT EXISTS ux_clients_email
            ON clients (email);

        CREATE TABLE IF NOT EXISTS products (
            id          SERIAL PRIMARY KEY,
            name        VARCHAR(200) NOT NULL,
            description TEXT,
            price       NUMERIC(15,2) NOT NULL,
            stock       INTEGER NOT NULL,
            created_at  TIMESTAMPTZ  NOT NULL DEFAULT NOW()
        );

        CREATE INDEX IF NOT EXISTS ix_products_name
            ON products (name);

        CREATE TABLE IF NOT EXISTS sales (
            id          SERIAL PRIMARY KEY,
            client_id   INTEGER NOT NULL,
            sold_at     TIMESTAMPTZ NOT NULL DEFAULT NOW(),
            total       NUMERIC(15,2) NOT NULL,

            CONSTRAINT fk_sales_client
                FOREIGN KEY (client_id)
                REFERENCES clients (id)
        );

        CREATE TABLE IF NOT EXISTS sale_items (
            id            SERIAL PRIMARY KEY,
            sale_id       INTEGER NOT NULL,
            product_id    INTEGER NOT NULL,
            product_name  VARCHAR(200) NOT NULL,
            quantity      INTEGER NOT NULL,
            unit_price    NUMERIC(15,2) NOT NULL,
            line_total    NUMERIC(15,2) NOT NULL,

            CONSTRAINT fk_sale_items_sale
                FOREIGN KEY (sale_id)
                REFERENCES sales (id)
                ON DELETE CASCADE,

            CONSTRAINT fk_sale_items_product
                FOREIGN KEY (product_id)
                REFERENCES products (id)
        );

        CREATE INDEX IF NOT EXISTS ix_sales_client_id
            ON sales (client_id);

        CREATE INDEX IF NOT EXISTS ix_sales_sold_at
            ON sales (sold_at);

        CREATE INDEX IF NOT EXISTS ix_sale_items_sale_id
            ON sale_items (sale_id);

        CREATE INDEX IF NOT EXISTS ix_sale_items_product_id
            ON sale_items (product_id);
    """;
}
