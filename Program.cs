using CityProviderApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CityService>();
var app = builder.Build();

// The service filters out cities outside Türkiye before returning the list.
app.MapGet("/api/cities", (CityService service) => Results.Ok(service.GetTurkishCities()));
app.MapGet("/", () => Results.Ok(new { service = "CityProviderApi", endpoint = "/api/cities" }));
app.Run();

