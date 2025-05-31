using NArchitecture.Core.Application.Responses;
using Domain.Enums;
namespace Application.Features.UserImages.Commands.Create;

public class CreatedUserImageResponse : IResponse
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public DescriptionType DescriptionType { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
    public required Guid UserId { get; set; }
    public required Guid FileAttachmentId { get; set; }
}
