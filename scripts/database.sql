CREATE TABLE clients (
    id          SERIAL PRIMARY KEY,
    name        VARCHAR(200) NOT NULL,
    email       VARCHAR(200) NOT NULL,
    phone       VARCHAR(30)  NOT NULL,
    created_at  TIMESTAMPTZ  NOT NULL DEFAULT NOW()
);

CREATE UNIQUE INDEX ux_clients_email
    ON clients (email);

CREATE TABLE products (
    id          SERIAL PRIMARY KEY,
    name        VARCHAR(200) NOT NULL,
    description TEXT,
    price       NUMERIC(15,2) NOT NULL,
    stock       INTEGER NOT NULL,
    created_at  TIMESTAMPTZ  NOT NULL DEFAULT NOW()
);

CREATE INDEX ix_products_name
    ON products (name);

CREATE TABLE sales (
    id          SERIAL PRIMARY KEY,
    client_id   INTEGER NOT NULL,
    sold_at     TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    total       NUMERIC(15,2) NOT NULL,

    CONSTRAINT fk_sales_client
        FOREIGN KEY (client_id)
        REFERENCES clients (id)
);

CREATE TABLE sale_items (
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

CREATE INDEX ix_sales_client_id
    ON sales (client_id);

CREATE INDEX ix_sales_sold_at
    ON sales (sold_at);

CREATE INDEX ix_sale_items_sale_id
    ON sale_items (sale_id);

CREATE INDEX ix_sale_items_product_id
    ON sale_items (product_id);
