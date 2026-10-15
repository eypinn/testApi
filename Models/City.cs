namespace CityProviderApi.Models;

public sealed class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public int Population { get; set; }
    public double AreaKm2 { get; set; }
}
