using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Data;

public sealed class CityDbContext(DbContextOptions<CityDbContext> options) : DbContext(options)
{
    public DbSet<Cities> Cities => Set<Cities>();
    public DbSet<CitiesVw> CitiesView => Set<CitiesVw>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitiesVw>(entity =>
{
            entity.HasNoKey();
            entity.ToView("CitiesVw", "dbo");
        });

    }
}
