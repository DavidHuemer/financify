namespace Financify.Common.Generators.Random;

/// <summary>
///     Handles the generation of random numbers.
/// </summary>
public interface IRandomNumberGenerator
{
    /// <summary>
    ///     Generates a random number between the given min and max values.
    /// </summary>
    /// <param name="minValue">The minimum random number</param>
    /// <param name="maxValue">The maximum random number</param>
    /// <returns>The generated random number</returns>
    int Next(int minValue, int maxValue);
}