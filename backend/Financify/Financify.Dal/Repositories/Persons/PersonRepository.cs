using AutoMapper;
using Financify.Dal.Data.Persons;
using Financify.Dal.db;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Interfaces.Persons;

namespace Financify.Dal.Repositories.Persons;

/// <summary>
///     Implementation of the <see cref="IPersonRepository" />
///     Repository for the person entity
/// </summary>
public class PersonRepository : IPersonRepository
{
    private readonly FinancifyDataContext _db;
    private readonly Mapper _mapper;

    public PersonRepository(FinancifyDataContext db)
    {
        _db = db;

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<PersonCreationData, Person>(); });
        _mapper = new Mapper(config);
    }

    public async Task<Person> AddPersonAsync(PersonCreationData personCreationData)
    {
        var person = _mapper.Map<PersonCreationData, Person>(personCreationData);
        await _db.Persons.AddRangeAsync(person);
        await _db.SaveChangesAsync();

        return person;
    }
}