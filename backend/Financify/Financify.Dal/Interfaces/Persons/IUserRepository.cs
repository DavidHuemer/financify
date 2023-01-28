using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;

namespace Financify.Dal.Interfaces.Persons;

/// <summary>
///     Repository for the <see cref="User" /> entity.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///     Adds a new user
    /// </summary>
    /// <param name="userCreationData">The data for creating a new user</param>
    /// <returns>The new created user</returns>
    Task<User> AddUserAsync(UserCreationData userCreationData);

    /// <summary>
    ///     Returns the user by the email address
    /// </summary>
    /// <param name="emailAddress">The email address for which is searched</param>
    /// <returns>The found user. Null if no user was found</returns>
    Task<User?> GetUserByEmailAddressAsync(string emailAddress);
}