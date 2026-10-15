using CityProviderApi.Data;
using CityProviderApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Environment variable: ConnectionStrings__SqlDatabase
var connectionString = builder.Configuration.GetConnectionString("SqlDatabase");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Missing connection string 'SqlDatabase'. Configure ConnectionStrings__SqlDatabase.");
}

builder.Services.AddDbContext<CityDbContext>(options =>
    options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure()));
builder.Services.AddScoped<CityService>();

var app = builder.Build();
app.MapControllers();
app.Run();
