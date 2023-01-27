using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;

namespace Financify.Dal.Interfaces.Persons;

/// <summary>
///     Repository for the <see cref="User" /> entity.
/// </summary>
public interface IUserRepository
{
    Task<User> AddUserAsync(UserCreationData userCreationData);
}