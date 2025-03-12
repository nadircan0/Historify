using FluentValidation;

namespace Application.Features.UserImages.Commands.Create;

public class CreateUserImageCommandValidator : AbstractValidator<CreateUserImageCommand>
{
    public CreateUserImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.UploadDate).NotEmpty();
    }
}