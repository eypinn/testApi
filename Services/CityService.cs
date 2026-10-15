using CityProviderApi.Data;
using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Services;

public sealed class CityService(CityDbContext dbContext)
{
    public async Task<IReadOnlyList<City>> GetTurkishCitiesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Cities
            .AsNoTracking()
            .Where(city => city.CountryCode == "TR")
            .OrderBy(city => city.Name)
            .Select(city => new City(city.Name, city.CountryCode, city.Population, city.AreaKm2))
            .ToListAsync(cancellationToken);
    }
}
