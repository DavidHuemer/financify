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
        var combined = text + salt;
        var hash = algorithm(combined);
        return new HashSalt(hash, salt);
    }
}