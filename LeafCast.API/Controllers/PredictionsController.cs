using LeafCast.API.Models.Local;
using LeafCast.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeafCast.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PredictionsController(IPredictionRepository repository) : ControllerBase
{
    private readonly IPredictionRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repository.GetAllAsync());

    [HttpPost("bulk")]
    public async Task<IActionResult> Post(List<PredictionRequest> request)
    {
        var result = await _repository.AddBulkAsync(request);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }
}