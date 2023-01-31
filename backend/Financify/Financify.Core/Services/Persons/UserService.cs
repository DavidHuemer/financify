using AutoMapper;
using Financify.Common.Authentication.Hashing;
using Financify.Common.Authentication.Jwt;
using Financify.Core.Interfaces.Persons;
using Financify.Dal.Data.Persons;
using Financify.Dal.Domain.Persons;
using Financify.Dal.Interfaces.Persons;
using Financify.Models.Dtos.PersonDtos.UserDtos;
using Financify.Models.Exceptions;
using Financify.Models.Resources.PersonResources.UserResources;

namespace Financify.Core.Services.Persons;

/// <summary>
///     Implementation of the <see cref="IUserService" /> interface.
///     Service for the users
/// </summary>
public class UserService : IUserService
{
    private readonly IHashSaltHandler _hashSaltHandler;
    private readonly IJwtHandler _jwtHandler;

    private readonly Mapper _mapper;
    private readonly IPersonRepository _personRepository;
    private readonly IUserRepository _userRepository;

    public UserService(IPersonRepository personRepository, IUserRepository userRepository,
        IHashSaltHandler hashSaltHandler, IJwtHandler jwtHandler)
    {
        _personRepository = personRepository;
        _userRepository = userRepository;
        _hashSaltHandler = hashSaltHandler;
        _jwtHandler = jwtHandler;

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserCreationDto, PersonCreationData>(); });
        _mapper = new Mapper(config);
    }

    public async Task<UserCreatedResource> AddUserAsync(UserCreationDto userCreationDto)
    {
        var personCreationData = _mapper.Map<PersonCreationData>(userCreationDto);
        var person = await _personRepository.AddPersonAsync(personCreationData);

        var hashSalt = _hashSaltHandler.GenerateHashSalt(userCreationDto.Password, 10);

        var userCreationData = new UserCreationData
        {
            PersonId = person.Id,
            Password = hashSalt.Hash,
            Salt = hashSalt.Salt
        };

        var user = await _userRepository.AddUserAsync(userCreationData);

        return new UserCreatedResource
        {
            UserId = user.Id
        };
    }

    public async Task<UserSignedInResource> SignInAsync(UserSignInDto userSignInDto)
    {
        var user = await _userRepository.GetUserByEmailAddressAsync(userSignInDto.Email);
        if (user is null)
            throw new EntityNotFoundException(nameof(User), $"No user with email {userSignInDto.Email} found.");

        var newHash = _hashSaltHandler.GenerateHash(userSignInDto.Password, user.Salt);

        if (newHash != user.Password)
            throw new PasswordMismatchException(newHash, user.Password);

        return new UserSignedInResource
        {
            UserId = user.Id,
            Token = _jwtHandler.GenerateToken(user.Person.Email, "User")
        };
    }
}