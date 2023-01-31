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

    private async Task<User> AddPersonAndUser()
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

        return user;
    }

    #region Add User

    [Fact]
    public async void AddUserAsync_WithValidData_ReturnsUser()
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

    #endregion

    #region Get User By Email Address

    [Fact]
    public async void GetUserByEmailAddressAsync_WithValidData_ReturnsUser()
    {
        var user = await AddPersonAndUser();
        var email = user.Person.Email;

        var userFromDb = await _userRepository.GetUserByEmailAddressAsync(email);

        Assert.NotNull(userFromDb);
        Assert.Equal(user.Id, userFromDb.Id);
        Assert.Equal(user.Password, userFromDb.Password);
        Assert.Equal(user.Salt, userFromDb.Salt);
        Assert.Equal(user.Person.Email, userFromDb.Person.Email);
    }

    [Fact]
    public async void GetUserByEmailAddressAsync_WithInvalidData_ReturnsNull()
    {
        var user = await AddPersonAndUser();
        var email = user.Person.Email;

        var userFromDb = await _userRepository.GetUserByEmailAddressAsync(email + "invalid");

        Assert.Null(userFromDb);
    }

    #endregion
}