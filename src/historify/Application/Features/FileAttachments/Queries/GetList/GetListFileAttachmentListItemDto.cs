using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FileAttachments.Queries.GetList;

public class GetListFileAttachmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required string StorageType { get; set; }
    public required Guid UserImageId { get; set; }
    public ICollection<IFormFile> Files { get; set; }
}
