using CityProviderApi.Models;
using CityProviderApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityProviderApi.Controllers;

[ApiController]
[Route("api/cities")]
public sealed class CitiesController : ControllerBase
{
    private readonly CityService _cityService;

    public CitiesController(CityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<City>> GetCities()
    {
        return Ok(_cityService.GetTurkishCities());
    }
}
