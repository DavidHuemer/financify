namespace Financify.Models.Exceptions;

/// <summary>
///     Should be thrown when an entity is not found
/// </summary>
public class EntityNotFoundException : FinancifyException
{
    public EntityNotFoundException(string entityName, string detail) : base("Entity not found", GetMessage(entityName),
        detail)
    {
    }

    private static string GetMessage(string entityName)
    {
        return entityName.Length == 0 ? "Entity not found" : $"Entity {entityName} not found";
    }
}