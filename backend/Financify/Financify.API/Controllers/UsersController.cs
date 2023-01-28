using Financify.Core.Interfaces.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Financify.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] UserCreationDto userCreationDto)
    {
        var userCreatedResource = await _userService.AddUserAsync(userCreationDto);
        return CreatedAtAction(nameof(SignUp), userCreatedResource);
    }
}