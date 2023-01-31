using Financify.Models.Exceptions;

namespace Financify.Tests.Models;

public class EntityNotFoundExceptionTests
{
    [Fact]
    public void EntityNotFoundException_Sets_TitleCorrect()
    {
        var exception = new EntityNotFoundException("Entity", "Detail");
        Assert.Equal("Entity not found", exception.Title);
    }

    [Theory]
    [InlineData("", "Entity not found")]
    [InlineData("a", "Entity a not found")]
    [InlineData("A", "Entity A not found")]
    [InlineData("User", "Entity User not found")]
    public void EntityNotFoundException_Sets_MessageCorrect(string title, string expected)
    {
        var exception = new EntityNotFoundException(title, "Detail");
        Assert.Equal(expected, exception.Message);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("A", "A")]
    [InlineData("User", "User")]
    [InlineData("No user found with email abc", "No user found with email abc")]
    public void EntityNotFoundException_Sets_DetailCorrect(string detail, string expectedDetail)
    {
        var exception = new EntityNotFoundException("Entity", detail);
        Assert.Equal(expectedDetail, exception.Detail);
    }
}