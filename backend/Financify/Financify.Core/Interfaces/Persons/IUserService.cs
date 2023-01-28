using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Resources.PersonResources.UserResources;

namespace Financify.Core.Interfaces.Persons;

/// <summary>
/// Service for the users
/// </summary>
public interface IUserService
{
    Task<UserCreatedResource> AddUserAsync(UserCreationDto userCreationDto);
}