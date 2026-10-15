using CityProviderApi.Models;
using CityProviderApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityProviderApi.Controllers;

[ApiController]
[Route("api/city-exceptions")]
public sealed class CityExceptionsController(CityExceptionService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CitiesIstisna>>> GetAll(CancellationToken ct) =>
        Ok(await service.GetAllAsync(ct));

    [HttpGet("{cityId:int}")]
    public async Task<ActionResult<CitiesIstisna>> GetById(int cityId, CancellationToken ct)
    {
        var item = await service.GetAsync(cityId, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPut("{cityId:int}")]
    public async Task<ActionResult<CitiesIstisna>> Upsert(int cityId, [FromBody] CityExceptionUpsertRequest request, CancellationToken ct)
    {
        if (cityId <= 0) return BadRequest("Geçerli bir şehir kimliği gerekli.");
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.CountryCode))
            return BadRequest("Şehir adı ve ülke kodu zorunludur.");
        if (!await service.CityExistsAsync(cityId, ct))
            return NotFound("Şehir dbo.Cities tablosunda bulunamadı.");
        return Ok(await service.UpsertAsync(cityId, request, ct));
    }

    [HttpDelete("{cityId:int}")]
    public async Task<IActionResult> Delete(int cityId, CancellationToken ct) =>
        await service.DeleteAsync(cityId, ct) ? NoContent() : NotFound();
}
