using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FileAttachments.Queries.GetList;

public class GetListFileAttachmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string StorageType { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UserImageId { get; set; }
}
