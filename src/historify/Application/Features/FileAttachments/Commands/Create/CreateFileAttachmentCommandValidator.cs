using FluentValidation;

namespace Application.Features.FileAttachments.Commands.Create;

public class CreateFileAttachmentCommandValidator : AbstractValidator<CreateFileAttachmentCommand>
{
    public CreateFileAttachmentCommandValidator()
    {
        RuleFor(c => c.FileName).NotEmpty();
        RuleFor(c => c.File).NotEmpty();
        RuleFor(c => c.UserImageId).NotEmpty();
    }
}
