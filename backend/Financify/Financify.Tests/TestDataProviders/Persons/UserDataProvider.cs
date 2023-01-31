using Financify.Dal.Domain.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;

namespace Financify.Tests.TestDataProviders.Persons;

/// <summary>
///     Provides users
/// </summary>
public static class UserDataProvider
{
    private const int DefaultUserId = 1;
    private const int DefaultPersonId = 1;
    private const string DefaultPassword = "example password";
    public const string DefaultHashedPassword = "hashed password";
    private const string DefaultSalt = "example salt";

    public static User ProvideUser()
    {
        return new User
        {
            Id = DefaultUserId,
            PersonId = DefaultPersonId,
            Password = DefaultHashedPassword,
            Salt = DefaultSalt,
            Person = PersonDataProvider.ProvidePerson()
        };
    }

    public static UserSignInDto ProvideUserSignInDto()
    {
        return new UserSignInDto
        {
            Email = PersonDataProvider.DefaultEmail,
            Password = DefaultPassword
        };
    }
}