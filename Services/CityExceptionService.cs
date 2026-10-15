using CityProviderApi.Data;
using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Services;

public sealed class CityExceptionService(CityDbContext context)
{
    public Task<List<CitiesIstisna>> GetAllAsync(CancellationToken ct) =>
        context.CitiesIstisna.AsNoTracking().OrderBy(x => x.CityId).ToListAsync(ct);

    public Task<CitiesIstisna?> GetAsync(int cityId, CancellationToken ct) =>
        context.CitiesIstisna.AsNoTracking().FirstOrDefaultAsync(x => x.CityId == cityId, ct);

    public Task<bool> CityExistsAsync(int cityId, CancellationToken ct) =>
        context.Cities.AnyAsync(x => x.Id == cityId, ct);

    public async Task<CitiesIstisna> UpsertAsync(int cityId, CityExceptionUpsertRequest request, CancellationToken ct)
    {
        var entry = await context.CitiesIstisna.FindAsync([cityId], ct);
        if (entry is null)
        {
            entry = new CitiesIstisna { CityId = cityId };
            context.CitiesIstisna.Add(entry);
        }
        entry.Name = request.Name.Trim();
        entry.CountryCode = request.CountryCode.Trim().ToUpperInvariant();
        entry.Population = request.Population;
        entry.AreaKm2 = request.AreaKm2;
        entry.Reason = request.Reason?.Trim();
        await context.SaveChangesAsync(ct);
        return entry;
    }

    public async Task<bool> DeleteAsync(int cityId, CancellationToken ct)
    {
        var entry = await context.CitiesIstisna.FindAsync([cityId], ct);
        if (entry is null) return false;
        context.CitiesIstisna.Remove(entry);
        await context.SaveChangesAsync(ct);
        return true;
    }
}
