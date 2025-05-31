using NArchitecture.Core.Application.Responses;

namespace Application.Features.FileAttachments.Queries.Download;

public class DownloadFileAttachmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileData { get; set; }
}
