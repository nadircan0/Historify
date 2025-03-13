using Application.Features.FileAttachments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FileAttachments.Commands.Update;

public class UpdateFileAttachmentCommand : IRequest<UpdatedFileAttachmentResponse>
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required string StorageType { get; set; }
    public DateTime? UploadDate { get; set; }
    public required Guid UserImageId { get; set; }

    public class UpdateFileAttachmentCommandHandler : IRequestHandler<UpdateFileAttachmentCommand, UpdatedFileAttachmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFileAttachmentRepository _fileAttachmentRepository;
        private readonly FileAttachmentBusinessRules _fileAttachmentBusinessRules;

        public UpdateFileAttachmentCommandHandler(
            IMapper mapper,
            IFileAttachmentRepository fileAttachmentRepository,
            FileAttachmentBusinessRules fileAttachmentBusinessRules
        )
        {
            _mapper = mapper;
            _fileAttachmentRepository = fileAttachmentRepository;
            _fileAttachmentBusinessRules = fileAttachmentBusinessRules;
        }

        public async Task<UpdatedFileAttachmentResponse> Handle(
            UpdateFileAttachmentCommand request,
            CancellationToken cancellationToken
        )
        {
            FileAttachment? fileAttachment = await _fileAttachmentRepository.GetAsync(
                predicate: fa => fa.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _fileAttachmentBusinessRules.FileAttachmentShouldExistWhenSelected(fileAttachment);
            fileAttachment = _mapper.Map(request, fileAttachment);

            await _fileAttachmentRepository.UpdateAsync(fileAttachment!);

            UpdatedFileAttachmentResponse response = _mapper.Map<UpdatedFileAttachmentResponse>(fileAttachment);
            return response;
        }
    }
}
