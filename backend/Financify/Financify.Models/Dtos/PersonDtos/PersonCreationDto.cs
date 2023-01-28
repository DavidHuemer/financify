using System.ComponentModel.DataAnnotations;

namespace Financify.Models.Dtos.PersonDtos;

/// <summary>
///     Contains the properties that are required to create a new person.
/// </summary>
public abstract record PersonCreationDto
{
    [Required] public string Email { get; set; } = null!;
    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
}