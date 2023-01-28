using Financify.Common.Authentication.Jwt;

namespace Financify.Tests.Common.Authentication.Jwt;

/// <summary>
///     Tests for the <see cref="JwtHandler" />
/// </summary>
public class JwtHandlerTests
{
    [Fact]
    public void JwtHandlerWithNoEnvironmentVariable_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new JwtHandler());
    }

    [Fact]
    public void JwtHandlerWithEnvironmentVariable_ReturnsJwtHandler()
    {
        Environment.SetEnvironmentVariable(JwtHandler.JwtKey, "test");
        var jwtHandler = new JwtHandler();
        Assert.NotNull(jwtHandler);
    }

    [Fact]
    public void JwtHandlerWithParameter_ReturnsJwtHandler()
    {
        var jwtHandler = new JwtHandler("test");
        Assert.NotNull(jwtHandler);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(15)]
    public void JwtHandler_WithTooSmallSecret_ThrowsArgumentException(int length)
    {
        //Generate String with length of 31
        var key = new string('a', length);

        var jwtHandler = new JwtHandler(key);

        Assert.Throws<ArgumentOutOfRangeException>(() => jwtHandler.GenerateToken("test@test.com", "user"));
    }


    [Theory]
    [InlineData(16)]
    [InlineData(128)]
    [InlineData(1024)]
    public void JwtHandler_GeneratesToken(int length)
    {
        var key = new string('a', length);

        var jwtHandler = new JwtHandler(key);
        var token = jwtHandler.GenerateToken("john.doe@test.com", "user");
        Assert.NotNull(token);
    }
}