using CityProviderApi.Models;
using CityProviderApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityProviderApi.Controllers;

[ApiController]
[Route("api/cities")]
public sealed class CitiesController(CityService cityService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<City>>> GetCities(CancellationToken cancellationToken)
    {
        var cities = await cityService.GetTurkishCitiesAsync(cancellationToken);
        return Ok(cities);
    }
}
