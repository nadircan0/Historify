using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Security.Hashing;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreatedUserResponse>, ISecuredRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }

    public CreateUserCommand()
    {
        Email = string.Empty;
        Password = string.Empty;
        Name = string.Empty;
        Surname = string.Empty;
        UserName = string.Empty;
        CountryCode = string.Empty;
        PhoneNumber = string.Empty;
    }

    public CreateUserCommand(
        string email,
        string password,
        string name,
        string surname,
        string userName,
        string countryCode,
        string phoneNumber
    )
    {
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        UserName = userName;
        CountryCode = countryCode;
        PhoneNumber = phoneNumber;
    }

    public string[] Roles => new[] { Admin, Write, UsersOperationClaims.Create };

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);

            User user = _mapper.Map<User>(request);
            HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            User createdUser = await _userRepository.AddAsync(user);


            CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(user);
            return response;
        }
    }
}
