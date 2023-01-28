using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;

namespace Financify.Dal.Interfaces.Persons;

/// <summary>
///     Repository for the person entity
/// </summary>
public interface IPersonRepository
{
    Task<Person> AddPersonAsync(PersonCreationData personCreationData);
}