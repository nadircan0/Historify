using Domain.Enums;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Commands.Create;

public class CreatedFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required StorageType StorageType { get; set; }
    public DateTime UploadDate { get; set; }
    public required Guid UserImageId { get; set; }

}
