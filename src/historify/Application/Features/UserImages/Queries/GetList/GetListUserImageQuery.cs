using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserImages.Queries.GetList;

public class GetListUserImageQuery : IRequest<GetListResponse<GetListUserImageListItemDto>>
{
    public required PageRequest PageRequest { get; set; }

    public class GetListUserImageQueryHandler
        : IRequestHandler<GetListUserImageQuery, GetListResponse<GetListUserImageListItemDto>>
    {
        private readonly IUserImageRepository _userImageRepository;
        private readonly IMapper _mapper;

        public GetListUserImageQueryHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserImageListItemDto>> Handle(
            GetListUserImageQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<UserImage> userImages = await _userImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserImageListItemDto> response = _mapper.Map<GetListResponse<GetListUserImageListItemDto>>(
                userImages
            );
            return response;
        }
    }
}
