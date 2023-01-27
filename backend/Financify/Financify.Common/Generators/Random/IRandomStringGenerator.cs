namespace Financify.Common.Generators.Random;

/// <summary>
///     Handles the generation of random strings.
/// </summary>
public interface IRandomStringGenerator
{
    /// <summary>
    ///     Generates a random string with the given length.
    /// </summary>
    /// <param name="length">The length of the generated string</param>
    /// <returns>The randomly generated string</returns>
    string Generate(int length);
}