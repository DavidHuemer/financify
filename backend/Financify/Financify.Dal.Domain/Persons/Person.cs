using System.ComponentModel.DataAnnotations.Schema;

namespace Financify.Dal.Domain.Persons;

[Table("person")]
public class Person
{
    [Column("id")] public int Id { get; set; }

    [Column("email")] public string Email { get; set; } = null!;

    [Column("first_name")] public string FirstName { get; set; } = null!;

    [Column("last_name")] public string LastName { get; set; } = null!;
}