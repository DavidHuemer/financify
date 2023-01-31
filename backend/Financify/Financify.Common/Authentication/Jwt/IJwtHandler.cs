namespace Financify.Common.Authentication.Jwt;

/// <summary>
///     Handler for JWT tokens
/// </summary>
public interface IJwtHandler
{
    /// <summary>
    ///     Generates a JWT token for the email and the role
    /// </summary>
    /// <param name="email">The email that should be stored in the jwt</param>
    /// <param name="role">The role that should be stored in the jwt</param>
    /// <returns>The generated token</returns>
    string GenerateToken(string email, string role);
}