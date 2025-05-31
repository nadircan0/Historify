using FluentValidation;
using Application.Features.UserImages.Constants;

namespace Application.Features.UserImages.Commands.Create;

public class CreateUserImageCommandValidator : AbstractValidator<CreateUserImageCommand>
{
    public CreateUserImageCommandValidator()
    {

        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.DescriptionType).IsInEnum();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.File)
            .NotEmpty()
            .Must(file => file.Length > 0 && file.Length <= 10 * 1024 * 1024)
            .WithMessage("File size must be between 0 and 10MB")
            .Must(file => UserImagesConstants.AllowedMimeTypes.Contains(file.ContentType))
            .WithMessage($"Only the following file formats are accepted: {string.Join(", ", UserImagesConstants.AllowedMimeTypes)}");
    }
}
