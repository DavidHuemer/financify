using Financify.Dal.Domain.Persons;

namespace Financify.Tests.TestDataProviders.Persons;

/// <summary>
///     Provides persons
/// </summary>
public static class PersonDataProvider
{
    private const int DefaultPersonId = 1;
    public const string DefaultEmail = "john.doe@test.com";
    private const string DefaultFirstName = "John";
    private const string DefaultLastName = "Doe";

    public static Person ProvidePerson()
    {
        return new Person
        {
            Id = DefaultPersonId,
            FirstName = DefaultFirstName,
            LastName = DefaultLastName,
            Email = DefaultEmail
        };
    }
}