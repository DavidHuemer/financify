using Financify.API.Controllers;
using Financify.Core.Interfaces.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Resources.PersonResources.UserResources;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Financify.Tests.API.Controllers;

public class UsersControllerTests
{
    private readonly UsersController _usersController;
    private readonly Mock<IUserService> _userServiceMock = new();

    public UsersControllerTests()
    {
        _usersController = new UsersController(_userServiceMock.Object);
    }

    [Fact]
    public async void SignUp_Calls_UserService_AddUserAsync()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@test.com",
            Password = "examplePassword"
        };
        await _usersController.SignUp(userCreationDto);
        _userServiceMock.Verify(x => x.AddUserAsync(userCreationDto), Times.Once);
    }

    [Fact]
    public async void SignUp_Returns_CreatedAtAction()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@test.com",
            Password = "examplePassword"
        };

        var userCreatedResource = await _usersController.SignUp(userCreationDto);

        Assert.IsType<CreatedAtActionResult>(userCreatedResource);
    }

    [Fact]
    public async void SignUp_Returns_CreatedAtAction_With_UserCreatedResource()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@test.com",
            Password = "examplePassword"
        };

        var expected = new UserCreatedResource
        {
            UserId = 1
        };

        _userServiceMock.Setup(x => x.AddUserAsync(userCreationDto)).ReturnsAsync(expected);

        var userCreatedResource = await _usersController.SignUp(userCreationDto);

        Assert.IsType<UserCreatedResource>(((CreatedAtActionResult)userCreatedResource).Value);
    }

    [Fact]
    public async void SignUp_Returns_CreatedAtAction_With_UserCreatedResource_With_UserId()
    {
        var userCreationDto = new UserCreationDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@test.com",
            Password = "examplePassword"
        };

        var expected = new UserCreatedResource
        {
            UserId = 1
        };

        _userServiceMock.Setup(x => x.AddUserAsync(userCreationDto)).ReturnsAsync(expected);

        var actionResult = await _usersController.SignUp(userCreationDto);
        var createdAtActionResult = (actionResult as CreatedAtActionResult)!;
        var result = (createdAtActionResult.Value as UserCreatedResource)!;
        Assert.Equal(1, result.UserId);
    }
}