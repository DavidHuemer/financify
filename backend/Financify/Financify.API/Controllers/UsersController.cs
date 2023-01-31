using Financify.Core.Interfaces.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Exceptions;
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

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] UserSignInDto signInDto)
    {
        try
        {
            var user = await _userService.SignInAsync(signInDto);
            return Ok(user);
        }
        catch (EntityNotFoundException)
        {
            throw new InvalidEmailOrPasswordException(signInDto.Email, signInDto.Password);
        }
        catch (PasswordMismatchException)
        {
            throw new InvalidEmailOrPasswordException(signInDto.Email, signInDto.Password);
        }
    }
}