using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserImages.Queries.GetById;

public class GetByIdUserImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }

}