using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserImages.Commands.Update;

public class UpdatedUserImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
    public string StorageType { get; set; }
}