using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Historify.Application.SubServices;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.FileAttachments.Queries.GetById;

public class GetByIdFileAttachmentQuery : IRequest<GetByIdFileAttachmentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdFileAttachmentQueryHandler : IRequestHandler<GetByIdFileAttachmentQuery, GetByIdFileAttachmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;
        private readonly IStorageService _storageService;

        public GetByIdFileAttachmentQueryHandler(
            IMapper mapper,
            IFileAttachmentRepository fileAttachmentRepository,
            FileAttachmentBusinessRules fileAttachmentBusinessRules,
            IStorageService storageService
        )
        {
            _mapper = mapper;
            _fileAttachmentRepository = fileAttachmentRepository;
            _fileAttachmentBusinessRules = fileAttachmentBusinessRules;
            _storageService = storageService;
        }

        public async Task<GetByIdFileAttachmentResponse> Handle(
            GetByIdFileAttachmentQuery request,
            CancellationToken cancellationToken
        )
        {
            FileAttachment? fileAttachment = await _fileAttachmentRepository.GetAsync(
                predicate: fa => fa.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _fileAttachmentBusinessRules.FileAttachmentShouldExistWhenSelected(fileAttachment);

            IFormFile file = await _storageService.GetFileAsync(fileAttachment.FilePath, fileAttachment.FileName);

            GetByIdFileAttachmentResponse response = _mapper.Map<GetByIdFileAttachmentResponse>(fileAttachment);
            response.File = file;
            return response;
        }
    }
}

//todo add file to response and add relation of storage type//  look again
