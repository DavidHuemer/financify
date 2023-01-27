using Financify.Common.Authentication.Hashing;
using Financify.Core.Services.Persons;
using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Interfaces.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Resources.PersonResources.UserResources;
using Moq;

namespace Financify.Tests.Core.Services;

/// <summary>
///     Tests for the <see cref="UserService" />
/// </summary>
public class UserServiceTests
{
    private readonly Mock<IHashSaltHandler> _hashSaltHandlerMock = new();
    private readonly Mock<IPersonRepository> _personRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();

    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userService = new UserService(_personRepositoryMock.Object, _userRepositoryMock.Object,
            _hashSaltHandlerMock.Object);
    }

    [Fact]
    public async void AddUserAsync_Calls_PersonRepository_AddPersonAsync()
    {
        var person = SetupAddPerson(1, Email, FirstName, LastName);
        SetupAddUser(1, person.Id, person, HashPassword, SALT);

        var hashSalt = new HashSalt(HashPassword, SALT);
        _hashSaltHandlerMock.Setup(x => x.GenerateHashSalt(It.IsAny<string>(), It.IsAny<int>(), null))
            .Returns(hashSalt);

        var userCreationDto = GetUserCreationDto();

        await _userService.AddUserAsync(userCreationDto);
        _personRepositoryMock.Verify(x => x.AddPersonAsync(
                It.Is<PersonCreationData>(pcd =>
                    pcd.FirstName == FirstName &&
                    pcd.LastName == LastName &&
                    pcd.Email == Email))
            , Times.Once);
    }

    [Fact]
    public async void AddUserAsync_Calls_UserRepository_AddUserAsync()
    {
        var person = SetupAddPerson(1, Email, FirstName, LastName);
        SetupAddUser(1, person.Id, person, HashPassword, SALT);

        var hashSalt = new HashSalt(HashPassword, SALT);
        _hashSaltHandlerMock.Setup(x => x.GenerateHashSalt(It.IsAny<string>(), It.IsAny<int>(), null))
            .Returns(hashSalt);

        var userCreationDto = GetUserCreationDto();

        await _userService.AddUserAsync(userCreationDto);
        _userRepositoryMock.Verify(x => x.AddUserAsync(
                It.Is<UserCreationData>(ucd =>
                    ucd.PersonId == person.Id &&
                    ucd.Password == HashPassword &&
                    ucd.Salt == SALT))
            , Times.Once);
    }

    [Fact]
    public async void AddUserAsync_Calls_HashSaltHandler_GenerateHashSalt()
    {
        var person = SetupAddPerson(1, Email, FirstName, LastName);
        SetupAddUser(1, person.Id, person, HashPassword, SALT);

        var hashSalt = new HashSalt(HashPassword, SALT);
        _hashSaltHandlerMock.Setup(x => x.GenerateHashSalt(It.IsAny<string>(), It.IsAny<int>(), null))
            .Returns(hashSalt);

        var userCreationDto = GetUserCreationDto();

        await _userService.AddUserAsync(userCreationDto);
        _hashSaltHandlerMock.Verify(x => x.GenerateHashSalt(Password, It.IsAny<int>(), null), Times.Once);
    }

    [Fact]
    public async void AddUserAsync_Returns_UserCreatedResource()
    {
        var person = SetupAddPerson(1, Email, FirstName, LastName);
        var user = SetupAddUser(1, person.Id, person, HashPassword, SALT);

        var hashSalt = new HashSalt(HashPassword, SALT);
        _hashSaltHandlerMock.Setup(x => x.GenerateHashSalt(It.IsAny<string>(), It.IsAny<int>(), null))
            .Returns(hashSalt);

        var userCreationDto = GetUserCreationDto();

        var userResult = await _userService.AddUserAsync(userCreationDto);

        var expectedUserCreated = new UserCreatedResource
        {
            UserId = user.Id
        };

        Assert.Equal(expectedUserCreated, userResult);
    }

    private Person SetupAddPerson(int personId, string email, string firstName, string lastName)
    {
        var person = new Person
        {
            Id = personId,
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };
        _personRepositoryMock.Setup(x => x.AddPersonAsync(It.IsAny<PersonCreationData>()))
            .ReturnsAsync(person);

        return person;
    }

    private User SetupAddUser(int userId, int personId, Person person, string hashPassword, string salt)
    {
        var user = new User
        {
            Id = userId,
            PersonId = personId,
            Person = person,
            Password = hashPassword,
            Salt = salt
        };
        _userRepositoryMock.Setup(x => x.AddUserAsync(It.IsAny<UserCreationData>()))
            .ReturnsAsync(user);

        return user;
    }

    private UserCreationDto GetUserCreationDto()
    {
        return new UserCreationDto
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };
    }

    #region Constants

    private const string FirstName = "John";
    private const string LastName = "Doe";
    private const string Email = "john.doe@test.com";
    private const string Password = "example password 123";
    private const string HashPassword = "example hash password 123";
    private const string SALT = "example salt 123";

    #endregion
}