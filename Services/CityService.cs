using CityProviderApi.Data;
using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Services;

public sealed class CityService(CityDbContext context)
{
    public async Task<List<CitiesVw>> GetTurkishCitiesAsync(CancellationToken cancellationToken = default)
    {
        return await context.CitiesVw
            .AsNoTracking()
            .Where(x => x.CountryCode == "TR")
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
