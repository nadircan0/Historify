using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using Application.SubServices.StorageService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.FileAttachments.Commands.Create;

public class CreateFileAttachmentCommand : IRequest<CreatedFileAttachmentResponse>, ISecuredRequest
{
    public required string FileName { get; set; }
    public IFormFile File { get; set; }
    public required Guid UserImageId { get; set; }
    public string[] Roles => new[] { "Admin", "User" };

    public class CreateFileAttachmentCommandHandler : IRequestHandler<CreateFileAttachmentCommand, CreatedFileAttachmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;
        private readonly IStorage _storage;

        public CreateFileAttachmentCommandHandler(
            IMapper mapper,
            IFileAttachmentRepository fileAttachmentRepository,
            FileAttachmentBusinessRules fileAttachmentBusinessRules,
            IStorage storage
        )
        {
            _mapper = mapper;
            _fileAttachmentRepository = fileAttachmentRepository;
            _fileAttachmentBusinessRules = fileAttachmentBusinessRules;
            _storage = storage;
        }

        public async Task<CreatedFileAttachmentResponse> Handle(
            CreateFileAttachmentCommand request,
            CancellationToken cancellationToken
        )
        {
            string pathOrContainerName = "userImages";
            var uploadedFileAttribute = await _storage.UploadAsync(pathOrContainerName, request.File);

            FileAttachment fileAttachment = _mapper.Map<FileAttachment>(request);

            fileAttachment.FilePath = uploadedFileAttribute.filePath;
            fileAttachment.FileName = uploadedFileAttribute.fileName;
            fileAttachment.UploadDate = DateTime.Now;
            fileAttachment.StorageType = StorageType.Azure;

            await _fileAttachmentRepository.AddAsync(fileAttachment);

            CreatedFileAttachmentResponse response = _mapper.Map<CreatedFileAttachmentResponse>(fileAttachment);
            return response;
        }
    }
}
