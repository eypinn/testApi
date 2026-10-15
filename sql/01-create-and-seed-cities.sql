-- OPTIONAL demo setup. Run manually in the target Azure SQL database.
-- Do NOT run if an existing dbo.Cities table has a different schema.
IF OBJECT_ID(N'dbo.Cities', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Cities
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Cities PRIMARY KEY,
        Name nvarchar(150) NOT NULL,
        CountryCode varchar(2) NOT NULL,
        Population int NOT NULL,
        AreaKm2 float NOT NULL
    );
    CREATE INDEX IX_Cities_CountryCode ON dbo.Cities(CountryCode);
END;
GO
-- Only insert demo records if the table is empty.
IF NOT EXISTS (SELECT 1 FROM dbo.Cities)
BEGIN
    INSERT INTO dbo.Cities (Name, CountryCode, Population, AreaKm2)
    VALUES
        (N'İstanbul', 'TR', 15700000, 5343.22),
        (N'Ankara', 'TR', 5800000, 25632.0),
        (N'İzmir', 'TR', 4500000, 11891.0),
        (N'Bursa', 'TR', 3200000, 10882.0),
        (N'Berlin', 'DE', 3900000, 891.7);
END;
GO
