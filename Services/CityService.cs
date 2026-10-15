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

            .ToListAsync(cancellationToken);
    }
}
