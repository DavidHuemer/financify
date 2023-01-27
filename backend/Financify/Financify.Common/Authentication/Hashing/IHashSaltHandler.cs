namespace Financify.Common.Authentication.Hashing;

public interface IHashSaltHandler
{
    public delegate string HashingAlgorithm(string value);

    /// <summary>
    ///     Generates a hash and salt for the given text and algorithm. If no algorithm is given, SHA256 is used.
    /// </summary>
    /// <param name="text">The text that should be salted</param>
    /// <param name="saltLength">The length of the salt</param>
    /// <param name="algorithm">The chosen hash algorithm. If no algorithm is given SHA256 is used</param>
    /// <returns>The hash and salt</returns>
    HashSalt GenerateHashSalt(string text, int saltLength, HashingAlgorithm? algorithm = null);
}