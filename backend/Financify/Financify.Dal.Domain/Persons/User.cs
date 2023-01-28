using System.ComponentModel.DataAnnotations.Schema;

namespace Financify.Dal.Domain.Persons;

[Table("financify_user")]
public class User
{
    [Column("id")] public int Id { get; set; }

    [Column("person_id")] public int PersonId { get; set; }

    public Person Person { get; set; } = null!;

    [Column("password")] public string Password { get; set; } = null!;

    [Column("salt")] public string Salt { get; set; } = null!;
}