namespace Financify.Common.Authentication.Hashing;

public interface IHashSaltHandler
{
    public delegate string HashingAlgorithm(string value);

    /// <summary>
    ///     Generates a hash and salt for the given text and algorithm. If no algorithm is given, SHA256 is used.
    /// </summary>
    /// <param name="text">The text that should be hashed</param>
    /// <param name="saltLength">The length of the salt</param>
    /// <param name="algorithm">The chosen hash algorithm. If no algorithm is given SHA256 is used</param>
    /// <returns>The hash and salt</returns>
    HashSalt GenerateHashSalt(string text, int saltLength, HashingAlgorithm? algorithm = null);

    /// <summary>
    ///     Generates a hash for the given text, salt and algorithm. If no algorithm is given, SHA256 is used.
    /// </summary>
    /// <param name="text">The text that should be hashed</param>
    /// <param name="salt">The salt that should be added to the text</param>
    /// <param name="algorithm">The chosen hash algorithm. If no algorithm is given SHA256 is used</param>
    /// <returns>The hash</returns>
    string GenerateHash(string text, string salt, HashingAlgorithm? algorithm = null);

    /// <summary>
    ///     Generates a hash for the given text and algorithm. If no algorithm is given, SHA256 is used.
    /// </summary>
    /// <param name="text">The text that should be hashed</param>
    /// <param name="algorithm">The chosen hash algorithm. If no algorithm is given SHA256 is used</param>
    /// <returns></returns>
    string GenerateHash(string text, HashingAlgorithm? algorithm = null);
}