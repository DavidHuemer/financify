using System.Security.Cryptography;
using System.Text;

namespace Financify.Common.Authentication.Hashing;

public static class HashAlgorithms
{
    public static string Sha256(string value)
    {
        using (var sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array  
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Convert byte array to a string   
            var builder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();
        }
    }
}