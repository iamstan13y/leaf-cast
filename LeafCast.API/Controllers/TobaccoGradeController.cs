﻿using LeafCast.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeafCast.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TobaccoGradeController(ITobaccoGradeRepository repository) : ControllerBase
{
    private readonly ITobaccoGradeRepository _repository = repository;

    [HttpPost("bulk")]
    public async Task<IActionResult> Get() => Ok
}