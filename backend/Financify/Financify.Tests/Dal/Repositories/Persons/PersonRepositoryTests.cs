using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Repositories.Persons;
using Financify.Tests.Dal.Basics;

namespace Financify.Tests.Dal.Repositories.Persons;

/// <summary>
///     Tests for the <see cref="PersonRepository" /> class.
/// </summary>
public class PersonRepositoryTests : FinancifyDataContextTestBase
{
    private readonly PersonRepository _personRepository;

    public PersonRepositoryTests()
    {
        _personRepository = new PersonRepository(Context);
    }

    [Fact]
    public void PersonRepositoryCreated()
    {
        Assert.NotNull(_personRepository);
    }

    [Fact]
    public async void AddPersonAsync_WithValidData_ReturnsPerson()
    {
        const string email = "john.doe@test.com";
        const string firstName = "John";
        const string lastName = "Doe";

        var personCreationData = new PersonCreationData(email, firstName, lastName);
        var person = await _personRepository.AddPersonAsync(personCreationData);

        var expectedPerson = new Person
        {
            Id = 1,
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };

        //Check that expectedPerson is equal to person without using the Equals method in Person.cs
        Assert.True(person.Id > 0);
        Assert.Equal(expectedPerson.Email, person.Email);
        Assert.Equal(expectedPerson.FirstName, person.FirstName);
        Assert.Equal(expectedPerson.LastName, person.LastName);
    }
}