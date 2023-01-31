using System.ComponentModel.DataAnnotations;

namespace Financify.Models.Dtos.PersonDtos.UserDtos;

public record UserSignInDto
{
    [Required] public string Email { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;
}