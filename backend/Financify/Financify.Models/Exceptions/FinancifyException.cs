namespace Financify.Models.Exceptions;

/// <summary>
///     Base exception for all financify exceptions
/// </summary>
public abstract class FinancifyException : Exception
{
    protected FinancifyException(string title, string message, string detail)
    {
        Title = title;
        Message = message;
        Detail = detail;
    }

    public string Title { get; set; }

    public string Message { get; set; }

    public string Detail { get; set; }
}