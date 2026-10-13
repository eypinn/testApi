using CityProviderApi.Models;

namespace CityProviderApi.Services;

public sealed class CityService
{
    // Demo values are illustrative, not official statistics.
    private static readonly City[] Cities =
    [
        new("İstanbul", "TR", 15_700_000, 5343.22),
        new("Ankara", "TR", 5_800_000, 25632.0),
        new("İzmir", "TR", 4_500_000, 11891.0),
        new("Bursa", "TR", 3_200_000, 10882.0),
        new("Berlin", "DE", 3_900_000, 891.7)
    ];

    public IReadOnlyList<City> GetTurkishCities() =>
        Cities.Where(city => city.CountryCode == "TR").ToArray();
}
