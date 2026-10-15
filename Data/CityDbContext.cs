using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Data;

public sealed class CityDbContext(DbContextOptions<CityDbContext> options) : DbContext(options)
{
    public DbSet<Cities> Cities => Set<Cities>();
    public DbSet<CitiesVw> CitiesVw => Set<CitiesVw>();
    public DbSet<CitiesIstisna> CitiesIstisna => Set<CitiesIstisna>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cities>(entity =>
        {
            entity.ToTable("Cities", "dbo");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<CitiesVw>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("CitiesVw", "dbo");
        });
        modelBuilder.Entity<CitiesIstisna>(entity =>
        {
            entity.ToTable("CitiesIstisna", "dbo");
            entity.HasKey(x => x.CityId);
            entity.Property(x => x.Name).HasMaxLength(150);
            entity.Property(x => x.CountryCode).HasMaxLength(10);
            entity.Property(x => x.Reason).HasMaxLength(250);
            entity.Property(x => x.AreaKm2).HasColumnType("decimal(12,2)");
        });
    }
}
