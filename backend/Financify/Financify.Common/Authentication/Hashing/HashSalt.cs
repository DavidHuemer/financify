namespace Financify.Common.Authentication.Hashing;

public record HashSalt
{
    public HashSalt(string hash, string salt)
    {
        Hash = hash;
        Salt = salt;
    }

    public string Hash { get; set; }

    public string Salt { get; set; }
}