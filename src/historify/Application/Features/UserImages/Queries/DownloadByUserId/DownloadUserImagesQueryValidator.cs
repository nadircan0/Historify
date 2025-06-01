using FluentValidation;

namespace Application.Features.UserImages.Queries.DownloadByUserId;

public class DownloadUserImagesQueryValidator : AbstractValidator<DownloadUserImagesQuery>
{
    public DownloadUserImagesQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required");
    }
}
