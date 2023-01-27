namespace Financify.Common.Generators.Random;

/// <summary>
///     Implementation of <see cref="IRandomNumberGenerator" />.
///     Handles the generation of random numbers.
/// </summary>
public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly System.Random _random;

    public RandomNumberGenerator()
    {
        _random = new System.Random();
    }

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
}