namespace Financify.Common.Generators.Random;

/// <summary>
///     Implementation of <see cref="IRandomStringGenerator" />.
///     Handles the generation of random strings.
/// </summary>
public class RandomStringGenerator : IRandomStringGenerator
{
    public const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public RandomStringGenerator()
    {
        RandomNumberGenerator = new RandomNumberGenerator();
    }

    public IRandomNumberGenerator RandomNumberGenerator { get; set; }

    public string Generate(int length)
    {
        if (length < 0) length = 0;

        return new string(Enumerable.Repeat(AllowedCharacters, length)
            .Select(s => s[RandomNumberGenerator.Next(0, s.Length - 1)]).ToArray());
    }
}