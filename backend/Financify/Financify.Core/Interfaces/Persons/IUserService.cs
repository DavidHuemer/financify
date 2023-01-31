using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Resources.PersonResources.UserResources;

namespace Financify.Core.Interfaces.Persons;

/// <summary>
/// Service for the users
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Adds a new user
    /// </summary>
    /// <param name="userCreationDto">The dto that contains the data for creating a new user</param>
    /// <returns>The created new user resource</returns>
    Task<UserCreatedResource> AddUserAsync(UserCreationDto userCreationDto);

    /// <summary>
    ///     Signs in a user
    /// </summary>
    /// <param name="userSignInDto">The dto that contains the data for sign a user in</param>
    /// <returns>The signed in user resource</returns>
    Task<UserSignedInResource> SignInAsync(UserSignInDto userSignInDto);
}