using Application.Features.UserImages.Constants;
using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserImages.Commands.Delete;

public class DeleteUserImageCommand : IRequest<DeletedUserImageResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserImageCommandHandler : IRequestHandler<DeleteUserImageCommand, DeletedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;

        public DeleteUserImageCommandHandler(IMapper mapper, IUserImageRepository userImageRepository,
                                         UserImageBusinessRules userImageBusinessRules)
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
        }

        public async Task<DeletedUserImageResponse> Handle(DeleteUserImageCommand request, CancellationToken cancellationToken)
        {
            UserImage? userImage = await _userImageRepository.GetAsync(predicate: ui => ui.Id == request.Id, cancellationToken: cancellationToken);
            await _userImageBusinessRules.UserImageShouldExistWhenSelected(userImage);

            await _userImageRepository.DeleteAsync(userImage!);

            DeletedUserImageResponse response = _mapper.Map<DeletedUserImageResponse>(userImage);
            return response;
        }
    }
}
