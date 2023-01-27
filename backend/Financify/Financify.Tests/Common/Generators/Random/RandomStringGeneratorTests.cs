using Financify.Common.Generators.Random;
using Moq;

namespace Financify.Tests.Common.Generators.Random;

/// <summary>
///     Tests for <see cref="RandomStringGenerator" />.
/// </summary>
public class RandomStringGeneratorTests
{
    private readonly RandomStringGenerator _randomStringGenerator;

    public RandomStringGeneratorTests()
    {
        _randomStringGenerator = new RandomStringGenerator();
    }

    [Fact(DisplayName = "Generate when called returns random string")]
    public void Generate_WhenCalled_ReturnsRandomString()
    {
        var result = _randomStringGenerator.Generate(10);

        Assert.True(result.Length == 10);
    }

    [Fact(DisplayName = "Generate when called with negative length returns empty string")]
    public void Generate_WhenCalledWithNegativeLength_ReturnsEmptyString()
    {
        var result = _randomStringGenerator.Generate(-1);
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Generate when called with minimum length returns empty string")]
    public void Generate_WhenCalledWithMinimumLength_ReturnsEmptyString()
    {
        var result = _randomStringGenerator.Generate(int.MinValue);
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Generate when called with zero length returns empty string")]
    public void Generate_WhenCalledWithZeroLength_ReturnsEmptyString()
    {
        var result = _randomStringGenerator.Generate(0);
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Generate when called with 1 length returns string with maximum length")]
    public void Generate_WhenCalledWith1Length_ReturnsStringWithMaximumLength()
    {
        const int length = 1;
        var result = _randomStringGenerator.Generate(length);
        Assert.True(result.Length == length);
    }

    [Fact(DisplayName = "Generate when called with 10.000 length returns string with maximum length")]
    public void Generate_WhenCalledWith10000Length_ReturnsStringWithMaximumLength()
    {
        const int length = 10_000;
        var result = _randomStringGenerator.Generate(length);
        Assert.True(result.Length == length);
    }

    [Fact(DisplayName = "Generate returns correct string")]
    public void Generate_Returns_CorrectString()
    {
        var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
        randomNumberGeneratorMock.SetupSequence(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(0)
            .Returns(1)
            .Returns(RandomStringGenerator.AllowedCharacters.Length - 1);

        _randomStringGenerator.RandomNumberGenerator = randomNumberGeneratorMock.Object;
        const string expected = "ab9";

        var result = _randomStringGenerator.Generate(3);
        Assert.Equal(expected, result);
    }
}