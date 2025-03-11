using FluentValidation;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
 public CreateUserCommandValidator()
{
    RuleFor(c => c.Email).NotEmpty().EmailAddress();
    RuleFor(c => c.UserName).NotEmpty();
    RuleFor(c => c.Name).NotEmpty();
    RuleFor(c => c.Surname).NotEmpty();
    RuleFor(c => c.CountryCode).NotEmpty();
    RuleFor(c => c.PhoneNumber).NotEmpty();
}
}
