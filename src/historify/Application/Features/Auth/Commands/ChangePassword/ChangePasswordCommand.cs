using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UsersService;

using MediatR;

namespace Application.Features.Auth.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly AuthBusinessRules _authBusinessRules;

        public ChangePasswordCommandHandler(
            IAuthService authService,
            IUserService userService,
            AuthBusinessRules authBusinessRules)
        {
            _authService = authService;
            _userService = userService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.CurrentPasswordShouldBeValid(request.CurrentPassword);
            await _authBusinessRules.NewPasswordShouldBeValid(request.NewPassword);
            await _authBusinessRules.NewPasswordShouldBeDifferentFromCurrent(request.CurrentPassword, request.NewPassword);

            await _userService.ChangePasswordAsync(request.CurrentPassword, request.NewPassword);

            return new ChangePasswordResponse(true, "Şifreniz başarıyla değiştirildi.");
        }
    }
}
