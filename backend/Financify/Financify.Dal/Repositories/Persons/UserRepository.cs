using AutoMapper;
using Financify.Dal.Data.Persons;
using Financify.Dal.db;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Interfaces.Persons;
using Microsoft.EntityFrameworkCore;

namespace Financify.Dal.Repositories.Persons;

/// <summary>
///     Implementation of <see cref="IUserRepository" />
///     Repository for the <see cref="User" /> entity.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly FinancifyDataContext _db;
    private readonly Mapper _mapper;

    public UserRepository(FinancifyDataContext db)
    {
        _db = db;

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserCreationData, User>(); });
        _mapper = new Mapper(config);
    }

    public async Task<User> AddUserAsync(UserCreationData userCreationData)
    {
        var user = _mapper.Map<User>(userCreationData);
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();

        return _db.Users.Where(x => x.Id == user.Id).Include(x => x.Person).First();
    }

    public Task<User?> GetUserByEmailAddressAsync(string emailAddress)
    {
        return _db.Users
            .Where(x => x.Person.Email == emailAddress).Include(x => x.Person).FirstOrDefaultAsync();
    }
}