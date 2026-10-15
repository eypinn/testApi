-- Azure SQL / Knime: execute manually once. Existing dbo.Cities and dbo.CitiesVw remain unchanged.
-- The current CityDbContext expects dbo.CitiesIstisna.CityId, Name, CountryCode,
-- Population, AreaKm2 and Reason. Match existing schema before running.
IF OBJECT_ID(N'dbo.CitiesIstisna', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CitiesIstisna
    (
        CityId int NOT NULL CONSTRAINT PK_CitiesIstisna PRIMARY KEY,
        Name nvarchar(150) NOT NULL,
        CountryCode nvarchar(10) NOT NULL,
        Population int NULL,
        AreaKm2 decimal(12,2) NULL,
        Reason nvarchar(250) NULL,
        CONSTRAINT FK_CitiesIstisna_Cities FOREIGN KEY (CityId) REFERENCES dbo.Cities(Id)
    );
END;
GO
-- No automatic seed: exceptions are created from the management screen.
-- API identity requires SELECT/INSERT/UPDATE/DELETE on dbo.CitiesIstisna,
-- SELECT on dbo.Cities and SELECT on dbo.CitiesVw.
