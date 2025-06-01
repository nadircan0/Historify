using FluentValidation;

namespace Application.Features.Auth.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(c => c.CurrentPassword)
            .NotEmpty()
            .WithMessage("Mevcut şifre boş olamaz.")
            .MinimumLength(6)
            .WithMessage("Mevcut şifre en az 6 karakter olmalıdır.")
            .MaximumLength(20)
            .WithMessage("Mevcut şifre en fazla 20 karakter olmalıdır.");

        RuleFor(c => c.NewPassword)
            .NotEmpty()
            .WithMessage("Yeni şifre boş olamaz.")
            .MinimumLength(6)
            .WithMessage("Yeni şifre en az 6 karakter olmalıdır.")
            .MaximumLength(20)
            .WithMessage("Yeni şifre en fazla 20 karakter olmalıdır.")
            .Must((command, newPassword) => newPassword != command.CurrentPassword)
            .WithMessage("Yeni şifre mevcut şifre ile aynı olamaz.");
    }
}
