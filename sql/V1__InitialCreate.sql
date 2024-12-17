CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Orders" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "CustomerName" TEXT NOT NULL
);

CREATE TABLE "OrderDetails" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_OrderDetails" PRIMARY KEY AUTOINCREMENT,
    "OrderId" INTEGER NOT NULL,
    "ProductName" TEXT NOT NULL,
    "Quantity" INTEGER NOT NULL,
    CONSTRAINT "FK_OrderDetails_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_OrderDetails_OrderId" ON "OrderDetails" ("OrderId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241217132457_InitialCreate', '9.0.0');
