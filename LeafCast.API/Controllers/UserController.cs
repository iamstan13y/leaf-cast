using LeafCast.API.Extensions;
using LeafCast.API.Models.Data;
using LeafCast.API.Models.Local;
using LeafCast.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeafCast.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController(IUserRepository repository) : ControllerBase
{
    private readonly IUserRepository _repository = repository;

    [HttpPost("create")]
    public async Task<IActionResult> Post(CreateAccountRequest request)
    {
        var result = await _repository.AddAsync(new User
        {
            UserName = request.UserName,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber.ToZimMobileNumber()
        });

        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }
}