using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Application.SubServices.StorageService;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.FileAttachments.Queries.GetList;

public class GetListFileAttachmentQuery : IRequest<GetListResponse<GetListFileAttachmentListItemDto>>, ISecuredRequest
{
    public required PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { "Admin", "User" };

    public class GetListFileAttachmentQueryHandler
        : IRequestHandler<GetListFileAttachmentQuery, GetListResponse<GetListFileAttachmentListItemDto>>
    {
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public GetListFileAttachmentQueryHandler(
            IFileAttachmentRepository fileAttachmentRepository,
            IMapper mapper,
            IStorageService storageService
        )
        {
            _fileAttachmentRepository = fileAttachmentRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<GetListResponse<GetListFileAttachmentListItemDto>> Handle(
            GetListFileAttachmentQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<FileAttachment> fileAttachments = await _fileAttachmentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFileAttachmentListItemDto> response = _mapper.Map<
                GetListResponse<GetListFileAttachmentListItemDto>
            >(fileAttachments);

            foreach (var fileAttachment in fileAttachments.Items)
            {
                var dto = _mapper.Map<GetListFileAttachmentListItemDto>(fileAttachment);
                var file = await _storageService.GetFileAsync(fileAttachment.FilePath, fileAttachment.FileName);
                dto.Files = new List<IFormFile> { file };
                response.Items.Add(dto);
            }
            return response;
        }
    }
}


// tekrar bakılacak
