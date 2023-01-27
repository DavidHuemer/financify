using Financify.Common.Generators.Random;

namespace Financify.Tests.Common.Generators.Random;

/// <summary>
///     Tests for <see cref="RandomNumberGenerator" />.
/// </summary>
public class RandomNumberGeneratorTests
{
    private readonly RandomNumberGenerator _randomNumberGenerator;

    public RandomNumberGeneratorTests()
    {
        _randomNumberGenerator = new RandomNumberGenerator();
    }

    [Fact(DisplayName = "Next when called returns random number")]
    public void Next_WhenCalled_ReturnsRandomNumber()
    {
        var result = _randomNumberGenerator.Next(0, 100);

        Assert.True(result is >= 0 and <= 100);
    }
}