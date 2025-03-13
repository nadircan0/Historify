using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserImages.Commands.Create;

public class CreatedUserImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
}
