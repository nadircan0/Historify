using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Commands.Update;

public class UpdatedFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required string StorageType { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UserImageId { get; set; }
}
