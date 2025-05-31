using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.UserForRegisterDto.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Must(StrongPassword)
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character."
            );
        RuleFor(c => c.UserForRegisterDto.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(c => c.UserForRegisterDto.Surname).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(c => c.UserForRegisterDto.UserName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(c => c.UserForRegisterDto.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(15);
        RuleFor(c => c.UserForRegisterDto.CountryCode).NotEmpty().MinimumLength(2).MaximumLength(5);

    }

    private bool StrongPassword(string value)
    {
        Regex strongPasswordRegex = new("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.Compiled);

        return strongPasswordRegex.IsMatch(value);
    }
}
