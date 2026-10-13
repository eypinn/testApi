using CityProviderApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<CityService>();

var app = builder.Build();
app.MapControllers();
app.Run();

