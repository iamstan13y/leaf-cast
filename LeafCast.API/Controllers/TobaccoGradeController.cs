﻿using LeafCast.API.Models.Local;
using LeafCast.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeafCast.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TobaccoGradeController(ITobaccoGradeRepository repository) : ControllerBase
{
    private readonly ITobaccoGradeRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (!result.Success) return NotFound(result);

        return Ok(result);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> Post(List<GradeRequest> request)
    {
        var result = await _repository.AddBulkAsync(request);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }
}