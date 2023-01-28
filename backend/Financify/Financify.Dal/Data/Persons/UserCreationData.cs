namespace Financify.Dal.Data.Persons;

public record UserCreationData
{
    public int PersonId { get; set; }

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;
}