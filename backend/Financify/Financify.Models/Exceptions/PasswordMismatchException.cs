namespace Financify.Models.Exceptions;

/// <summary>
///     Should be thrown when two passwords do not match
/// </summary>
public class PasswordMismatchException : FinancifyException
{
    public PasswordMismatchException(string hashedPassword1, string hashedPassword2) : base("Password mismatch",
        "Two Passwords do not match",
        $"First password: {hashedPassword1}, second password: {hashedPassword2}")
    {
        HashedPassword1 = hashedPassword1;
        HashedPassword2 = hashedPassword2;
    }

    public string HashedPassword1 { get; }

    public string HashedPassword2 { get; }
}