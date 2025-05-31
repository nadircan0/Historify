using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
namespace Application.Features.UserImages.Commands.Update;

public class UpdateUserImageCommand : IRequest<UpdatedUserImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public required DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
    public string[] Roles => new[] { "Admin", "User" };

    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, UpdatedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public UpdateUserImageCommandHandler(
            IMapper mapper,
            IUserImageRepository userImageRepository,
            UserImageBusinessRules userImageBusinessRules
        )
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<UpdatedUserImageResponse> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage? userImage = await _userImageRepository.GetAsync(
                predicate: ui => ui.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _userImageBusinessRules.UserImageShouldExistWhenSelected(userImage);
            userImage = _mapper.Map(request, userImage);

            await _userImageRepository.UpdateAsync(userImage!);

            UpdatedUserImageResponse response = _mapper.Map<UpdatedUserImageResponse>(userImage);
            return response;
        }
    }
}
