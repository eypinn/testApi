using CityProviderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityProviderApi.Data;

public sealed class CityDbContext(DbContextOptions<CityDbContext> options) : DbContext(options)
{
    public DbSet<Cities> Cities => Set<Cities>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cities>(entity =>
        {
            entity.ToTable("Cities", "dbo");
            entity.HasKey(city => city.Id);
            entity.Property(city => city.Id).HasColumnName("Id");
            entity.Property(city => city.Name).HasMaxLength(150).IsRequired();
            entity.Property(city => city.CountryCode).HasMaxLength(2).IsUnicode(false).IsRequired();
            entity.Property(city => city.Population).IsRequired();
            entity.Property(city => city.AreaKm2).HasColumnType("float").IsRequired();
            entity.HasIndex(city => city.CountryCode);
        });
    }
}
