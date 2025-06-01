using Application.Features.FileAttachments.Queries.Download;
using Application.Features.UserImages.Constants;
using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.UserImages.Queries.DownloadByUserId;

public class DownloadUserImagesQuery : IRequest<List<DownloadUserImagesResponse>>, ISecuredRequest
{
    public Guid UserId { get; set; }

    public string[] Roles => [UserImagesOperationClaims.Admin, UserImagesOperationClaims.User, UserImagesOperationClaims.Read];

    public class DownloadUserImagesQueryHandler : IRequestHandler<DownloadUserImagesQuery, List<DownloadUserImagesResponse>>
    {
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DownloadUserImagesQueryHandler(
            IUserImageRepository userImageRepository,
            UserImageBusinessRules userImageBusinessRules,
            IMediator mediator,
            IMapper mapper
        )
        {
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<DownloadUserImagesResponse>> Handle(
            DownloadUserImagesQuery request,
            CancellationToken cancellationToken
        )
        {
            //get all user images
            var userImages = await _userImageRepository.GetListAsync(
                predicate: ui => ui.UserId == request.UserId,
                cancellationToken: cancellationToken
            );

            //create download responses
            var responses = new List<DownloadUserImagesResponse>();

            foreach (var userImage in userImages.Items)
            {
                var response = _mapper.Map<DownloadUserImagesResponse>(userImage);

                // FileAttachment bilgilerini al ve maple
                var downloadQuery = new DownloadFileAttachmentQuery { Id = userImage.FileAttachmentId };
                var downloadResponse = await _mediator.Send(downloadQuery, cancellationToken);
                _mapper.Map(downloadResponse, response);

                responses.Add(response);
            }

            return responses;
        }
    }
}
