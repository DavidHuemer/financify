using Financify.Models.Exceptions;

namespace Financify.Tests.Models;

/// <summary>
///     Tests for the <see cref="PasswordMismatchException" /> class
/// </summary>
public class PasswordMismatchExceptionTests
{
    [Fact]
    public void PasswordMismatchException_Sets_TitleCorrect()
    {
        var exception = new PasswordMismatchException("HashedPassword1", "HashedPassword2");
        Assert.Equal("Password mismatch", exception.Title);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("a", "b")]
    [InlineData("pass 1", "pass 2")]
    public void PasswordMismatchException_Sets_MessageCorrect(string hashedPassword1, string hashedPassword2)
    {
        var exception = new PasswordMismatchException(hashedPassword1, hashedPassword2);
        Assert.Equal("Two Passwords do not match", exception.Message);
    }

    [Theory]
    [InlineData("", "", "First password: , second password: ")]
    [InlineData("a", "b", "First password: a, second password: b")]
    [InlineData("pass 1", "pass 2", "First password: pass 1, second password: pass 2")]
    public void PasswordMismatchException_Sets_DetailCorrect(string hashedPassword1, string hashedPassword2,
        string expectedDetail)
    {
        var exception = new PasswordMismatchException(hashedPassword1, hashedPassword2);
        Assert.Equal(expectedDetail, exception.Detail);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("a", "b")]
    [InlineData("pass 1", "pass 2")]
    public void PasswordMismatchException_Sets_HashedPassword1Correct(string hashedPassword1, string hashedPassword2)
    {
        var exception = new PasswordMismatchException(hashedPassword1, hashedPassword2);
        Assert.Equal(hashedPassword1, exception.HashedPassword1);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("a", "b")]
    [InlineData("pass 1", "pass 2")]
    public void PasswordMismatchException_Sets_HashedPassword2Correct(string hashedPassword1, string hashedPassword2)
    {
        var exception = new PasswordMismatchException(hashedPassword1, hashedPassword2);
        Assert.Equal(hashedPassword2, exception.HashedPassword2);
    }
}