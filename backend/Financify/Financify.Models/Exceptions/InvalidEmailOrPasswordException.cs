namespace Financify.Models.Exceptions;

public class InvalidEmailOrPasswordException : FinancifyException
{
    public InvalidEmailOrPasswordException(string email, string password) : base("Unauthorized",
        "Invalid email or password.", $"Email: {email}, Password: {password}")
    {
    }
}