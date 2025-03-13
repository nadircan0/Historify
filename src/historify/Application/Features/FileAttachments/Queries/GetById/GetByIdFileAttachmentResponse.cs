using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Queries.GetById;

public class GetByIdFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public required string FileName { get; set; }
    public required string FilePath { get; set; }
    public required string StorageType { get; set; }
    public required Guid UserImageId { get; set; }
    public required IFormFile File { get; set; }
}
