using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Repositories.Persons;
using Financify.Tests.Dal.Basics;

namespace Financify.Tests.Dal.Repositories.Persons;

/// <summary>
///     Tests for the <see cref="UserRepository" /> class.
/// </summary>
public class UserRepositoryTests : FinancifyDataContextTestBase
{
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        _userRepository = new UserRepository(Context);
    }

    [Fact]
    public void UserRepositoryCreated()
    {
        Assert.NotNull(_userRepository);
    }

    [Fact]
    public async void AddUserAsync_WithValidData_ReturnsUser()
    {
        await AddPerson();

        const string passwordHash = "password";
        const string passwordSalt = "salt";

        var userCreationData = new UserCreationData
        {
            PersonId = 1,
            Password = passwordHash,
            Salt = passwordSalt
        };

        var user = await _userRepository.AddUserAsync(userCreationData);

        Assert.Equal(1, user.Id);
        Assert.Equal(passwordHash, user.Password);
        Assert.Equal(passwordSalt, user.Salt);
    }

    [Fact]
    public async void AddUserAsync_SetsPerson()
    {
        var person = await AddPerson();

        const string passwordHash = "password";
        const string passwordSalt = "salt";

        var userCreationData = new UserCreationData
        {
            PersonId = person.Id,
            Password = passwordHash,
            Salt = passwordSalt
        };

        var user = await _userRepository.AddUserAsync(userCreationData);

        Assert.NotNull(user.Person);
        Assert.Equal(person.Id, user.Person.Id);
        Assert.Equal(person.Email, user.Person.Email);
        Assert.Equal(person.FirstName, user.Person.FirstName);
        Assert.Equal(person.LastName, user.Person.LastName);
    }

    private async Task<Person> AddPerson()
    {
        const string email = "john.doe@test.com";
        const string firstName = "John";
        const string lastName = "Doe";

        var person = new Person
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };

        await Context.Persons.AddAsync(person);
        await Context.SaveChangesAsync();

        return person;
    }
}