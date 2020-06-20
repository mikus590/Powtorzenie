IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Klienci] (
    [IdKlient] int NOT NULL IDENTITY,
    [Imie] nvarchar(50) NULL,
    [Nazwisko] int NOT NULL,
    CONSTRAINT [PK_Klienci] PRIMARY KEY ([IdKlient])
);

GO

CREATE TABLE [Zamówienia] (
    [IdZamówienia] int NOT NULL IDENTITY,
    [DataPrzyjecia] datetime2 NOT NULL,
    [DataRealizacji] datetime2 NULL,
    [Uwagi] nvarchar(300) NULL,
    [IdKlient] int NOT NULL,
    [IdPracownika] int NOT NULL,
    CONSTRAINT [PK_Zamówienia] PRIMARY KEY ([IdZamówienia]),
    CONSTRAINT [FK_Zamówienia_Klienci_IdKlient] FOREIGN KEY ([IdKlient]) REFERENCES [Klienci] ([IdKlient]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Zamówienia_IdKlient] ON [Zamówienia] ([IdKlient]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200614103529_InitialMigration', N'2.1.14-servicing-32113');

GO

ALTER TABLE [Zamówienia] ADD [IdPracownik] int NULL;

GO

CREATE TABLE [Pracownik] (
    [IdPracownik] int NOT NULL IDENTITY,
    [Imie] nvarchar(50) NULL,
    [Nazwisko] int NOT NULL,
    CONSTRAINT [PK_Pracownik] PRIMARY KEY ([IdPracownik])
);

GO

CREATE INDEX [IX_Zamówienia_IdPracownik] ON [Zamówienia] ([IdPracownik]);

GO

ALTER TABLE [Zamówienia] ADD CONSTRAINT [FK_Zamówienia_Pracownik_IdPracownik] FOREIGN KEY ([IdPracownik]) REFERENCES [Pracownik] ([IdPracownik]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200614103959_AddedPracownikTable', N'2.1.14-servicing-32113');

GO

ALTER TABLE [Zamówienia] DROP CONSTRAINT [FK_Zamówienia_Pracownik_IdPracownik];

GO

DROP INDEX [IX_Zamówienia_IdPracownik] ON [Zamówienia];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Zamówienia]') AND [c].[name] = N'IdPracownik');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Zamówienia] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Zamówienia] ALTER COLUMN [IdPracownik] int NOT NULL;
CREATE INDEX [IX_Zamówienia_IdPracownik] ON [Zamówienia] ([IdPracownik]);

GO

ALTER TABLE [Zamówienia] ADD CONSTRAINT [FK_Zamówienia_Pracownik_IdPracownik] FOREIGN KEY ([IdPracownik]) REFERENCES [Pracownik] ([IdPracownik]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200614105906_ChangeReq', N'2.1.14-servicing-32113');

GO

CREATE TABLE [WyrobCukierniczy] (
    [IdWyrobCukierniczy] int NOT NULL IDENTITY,
    [Nazwa] nvarchar(200) NOT NULL,
    [CenaZaSzt] real NOT NULL,
    [Typ] nvarchar(max) NULL,
    CONSTRAINT [PK_WyrobCukierniczy] PRIMARY KEY ([IdWyrobCukierniczy])
);

GO

CREATE TABLE [ZamowienieWyrob] (
    [IdWyrobuCukierniczego] int NOT NULL,
    [IdZamowienia] int NOT NULL,
    [Ilosc] int NOT NULL,
    [Uwagi] nvarchar(300) NULL,
    CONSTRAINT [PK_ZamowienieWyrob] PRIMARY KEY ([IdZamowienia], [IdWyrobuCukierniczego]),
    CONSTRAINT [FK_ZamowienieWyrob_WyrobCukierniczy_IdWyrobuCukierniczego] FOREIGN KEY ([IdWyrobuCukierniczego]) REFERENCES [WyrobCukierniczy] ([IdWyrobCukierniczy]) ON DELETE CASCADE,
    CONSTRAINT [FK_ZamowienieWyrob_Zamówienia_IdZamowienia] FOREIGN KEY ([IdZamowienia]) REFERENCES [Zamówienia] ([IdZamówienia]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ZamowienieWyrob_IdWyrobuCukierniczego] ON [ZamowienieWyrob] ([IdWyrobuCukierniczego]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200614113459_AddZamowienieWyrob', N'2.1.14-servicing-32113');

GO

