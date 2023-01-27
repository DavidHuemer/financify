using System.Security.Cryptography;
using System.Text;

namespace Financify.Common.Authentication.Hashing;

public static class HashAlgorithms
{
    public static string Sha256(string value)
    {
        // ComputeHash - returns byte array  
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));

        // Convert byte array to a string   
        var builder = new StringBuilder();
        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));

        return builder.ToString();
    }
}