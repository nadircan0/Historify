using Domain.Enums;
using NArchitecture.Core.Application.Responses;
namespace Application.Features.UserImages.Queries.DownloadById;

public class DownloadUserImagesResponse : IResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DescriptionType DescriptionType { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public Guid FileAttachmentId { get; set; }


    public DownloadUserImagesResponse()
    {
        Description = string.Empty;
        FileName = string.Empty;
        ContentType = string.Empty;
        FileAttachmentId = Guid.Empty;

    }
}
