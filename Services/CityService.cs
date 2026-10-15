using CityProviderApi.Data;
using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Services;

public sealed class CityService(CityDbContext _context)
{
    public async Task<List<CitiesVw>> GetTurkishCitiesAsync()
{
    return await _context.CitiesView
        .AsNoTracking()
        .Where(x => x.CountryCode == "TR")
        .ToListAsync();
}
}
