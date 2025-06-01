using Application.Features.FileAttachments.Commands.Create;
using Application.Features.FileAttachments.Commands.Update;
using Application.Features.UserImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.UserImages.Commands.Create;

public class CreateUserImageCommand : IRequest<CreatedUserImageResponse>, ISecuredRequest
{
    public required string Description { get; set; }
    public required DescriptionType DescriptionType { get; set; }
    public string? Tags { get; set; }
    public required Guid UserId { get; set; }
    public required IFormFile File { get; set; }
    public string[] Roles => new[] { "Admin", "User" };

    public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand, CreatedUserImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserImageBusinessRules _userImageBusinessRules;
        private readonly IMediator _mediator;

        public CreateUserImageCommandHandler(
            IMapper mapper,
            IUserImageRepository userImageRepository,
            UserImageBusinessRules userImageBusinessRules,
            IMediator mediator
        )
        {
            _mapper = mapper;
            _userImageRepository = userImageRepository;
            _userImageBusinessRules = userImageBusinessRules;
            _mediator = mediator;
        }

        public async Task<CreatedUserImageResponse> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
        {
            // First create the FileAttachment
            var createFileAttachmentCommand = new CreateFileAttachmentCommand
            {
                FileName = request.File.FileName,
                File = request.File,
                UserImageId = Guid.NewGuid() // Geçici bir ID oluştur
            };

            var fileAttachmentResponse = await _mediator.Send(createFileAttachmentCommand, cancellationToken);

            // Create UserImage with the FileAttachment ID
            UserImage userImage = _mapper.Map<UserImage>(request);
            userImage.FileAttachmentId = fileAttachmentResponse.Id;

            await _userImageRepository.AddAsync(userImage);

            // Update FileAttachment with the correct UserImage ID
            var updateFileAttachmentCommand = new UpdateFileAttachmentCommand
            {
                Id = fileAttachmentResponse.Id,
                FileName = fileAttachmentResponse.FileName,
                FilePath = fileAttachmentResponse.FilePath,
                StorageType = fileAttachmentResponse.StorageType.ToString(),
                UploadDate = fileAttachmentResponse.UploadDate,
                UserImageId = userImage.Id
            };

            await _mediator.Send(updateFileAttachmentCommand, cancellationToken);

            CreatedUserImageResponse response = _mapper.Map<CreatedUserImageResponse>(userImage);
            return response;
        }
    }
}
