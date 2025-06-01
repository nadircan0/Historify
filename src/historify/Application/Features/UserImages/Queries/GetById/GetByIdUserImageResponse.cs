using Domain.Enums;
using NArchitecture.Core.Application.Responses;
namespace Application.Features.UserImages.Queries.GetById;

public class GetByIdUserImageResponse : IResponse
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public DescriptionType DescriptionType { get; set; }
    public DateTime UploadDate { get; set; }
    public string? Tags { get; set; }
}
