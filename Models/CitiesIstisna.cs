using System.ComponentModel.DataAnnotations;

namespace CityProviderApi.Models;

public sealed class CitiesIstisna
{
    [Key]
    public int CityId { get; set; }
    [Required, StringLength(150)]
    public string Name { get; set; } = string.Empty;
    [Required, StringLength(10)]
    public string CountryCode { get; set; } = string.Empty;
    public int? Population { get; set; }
    public decimal? AreaKm2 { get; set; }
    [StringLength(250)]
    public string? Reason { get; set; }
}
