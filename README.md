# CityProviderApi - EF Core + Azure SQL demo

The original `GET /api/cities` endpoint now queries `dbo.Cities` through EF Core 10 instead of returning an in-memory array. The filter `CountryCode == "TR"` is translated into SQL. No raw SQL or stored procedures are executed by the application.

## Requirements

- .NET SDK 10
- Accessible Azure SQL Database
- Existing `dbo.Cities` table with columns `Id int`, `Name nvarchar(150)`, `CountryCode varchar(2)`, `Population int`, `AreaKm2 float`, **or** manually execute `sql/01-create-and-seed-cities.sql` in a demo database.

## Configuration

The app reads `ConnectionStrings:SqlDatabase` via `GetConnectionString`. Set the environment variable `ConnectionStrings__SqlDatabase` (double underscore) or use `dotnet user-secrets` locally. Do not commit credentials.

PowerShell example using SQL login:

```powershell
$env:ConnectionStrings__SqlDatabase = 'Server=tcp:YOUR_SERVER.database.windows.net,1433;Database=YOUR_DATABASE;User ID=YOUR_USER;Password=YOUR_PASSWORD;Encrypt=True;'
dotnet restore
dotnet run
```

For an Azure App Service with system-assigned managed identity:

```
Server=tcp:YOUR_SERVER.database.windows.net,1433;Database=YOUR_DATABASE;Authentication=Active Directory Managed Identity;Encrypt=True;
```

Depending on SqlClient authentication package versions, managed identity authentication may require adding `Microsoft.Data.SqlClient.Extensions.Azure` and aligning `Azure.Identity` package versions. This project intentionally only pins `Microsoft.EntityFrameworkCore.SqlServer` and uses standard EF Core provider defaults.

SQL principal needs `CONNECT` and `SELECT` on `dbo.Cities` for this demo. No schema modification permissions are needed at runtime. This differs from the metadata-only CodeMapSync account.

## Endpoint

`GET /api/cities` returns only Turkish cities from Azure SQL, sorted by name. `AsNoTracking` ensures read-only EF Core queries. No database migration or `EnsureCreated` is performed on startup.

## Important

The actual Azure database schema was not provided. This project assumes `dbo.Cities`; adjust `Data/CityDbContext.cs` to match existing table/column names and types. Seed values are illustrative demo values, not official statistics.
