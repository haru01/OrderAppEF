ALTER TABLE "Orders" ADD "CustomerId" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241217134707_AddNewColumn', '9.0.0');
