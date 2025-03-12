using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserImages.Commands.Create;

public class CreateUserImageCommand : IRequest<CreatedUserImageResponse>
{
    public required Guid Id { get; set; }
    public required string Description { get; set; }
    public required DateTime UploadDate { get; set; }
    public string? Tags { get; set; }

    public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand, CreatedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public CreateUserImageCommandHandler(IMapper mapper, IUserImageRepository userImageRepository,
                                         UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<CreatedUserImageResponse> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage userImage = _mapper.Map<UserImage>(request);

            await _userImageRepository.AddAsync(userImage);

            CreatedUserImageResponse response = _mapper.Map<CreatedUserImageResponse>(userImage);
            return response;
        }
    }
}