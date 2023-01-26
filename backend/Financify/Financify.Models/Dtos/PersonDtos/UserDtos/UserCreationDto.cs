using System.ComponentModel.DataAnnotations;

namespace Financify.Models.Dtos.PersonDtos.UserDtos;

/// <summary>
///     Contains the properties that are required to create a new user.
/// </summary>
public record UserCreationDto : PersonCreationDto
{
    [Required] public string Password { get; set; } = null!;
}