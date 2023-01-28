using Financify.Common.Generators.Random;

namespace Financify.Common.Authentication.Hashing;

public class HashSaltHandler : IHashSaltHandler
{
    public HashSaltHandler()
    {
        RandomStringGenerator = new RandomStringGenerator();
    }

    public IRandomStringGenerator RandomStringGenerator { get; set; }

    public HashSalt GenerateHashSalt(string text, int saltLength, IHashSaltHandler.HashingAlgorithm? algorithm = null)
    {
        algorithm ??= HashAlgorithms.Sha256;

        var salt = RandomStringGenerator.Generate(saltLength);
        var hash = GenerateHash(text, salt, algorithm);
        return new HashSalt(hash, salt);
    }

    public string GenerateHash(string text, string salt, IHashSaltHandler.HashingAlgorithm? algorithm = null)
    {
        algorithm ??= HashAlgorithms.Sha256;

        var textWithSalt = text + salt;
        return GenerateHash(textWithSalt, algorithm);
    }

    public string GenerateHash(string text, IHashSaltHandler.HashingAlgorithm? algorithm = null)
    {
        algorithm ??= HashAlgorithms.Sha256;
        return algorithm(text);
    }
}