using FluentValidation;

namespace Application.Features.FileAttachments.Commands.Update;

public class UpdateFileAttachmentCommandValidator : AbstractValidator<UpdateFileAttachmentCommand>
{
    public UpdateFileAttachmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FileName).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
        RuleFor(c => c.StorageType).NotEmpty();
    }
}
