using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Queries.GetById;

public class GetByIdFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string StorageType { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UserImageId { get; set; }
}