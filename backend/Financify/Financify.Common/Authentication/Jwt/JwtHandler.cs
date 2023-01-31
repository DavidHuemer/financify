using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Financify.Common.Authentication.Jwt;

/// <summary>
///     Implementation of <see cref="IJwtHandler" />
///     Handles JWT tokens
/// </summary>
public class JwtHandler : IJwtHandler
{
    public const string JwtKey = "JWT_SECRET";

    public JwtHandler(string? jwtSecret = null)
    {
        JwtSecret = jwtSecret ?? GetJwtSecret();
    }

    private string JwtSecret { get; }


    public string GenerateToken(string email, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(JwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("email", email),
                new Claim("role", role)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static string GetJwtSecret()
    {
        var jwtSecret = Environment.GetEnvironmentVariable(JwtKey);

        if (jwtSecret is null) throw new ArgumentException($"No {JwtKey} environment variable found.");

        return jwtSecret;
    }
}