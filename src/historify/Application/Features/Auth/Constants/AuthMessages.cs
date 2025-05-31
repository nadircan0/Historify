namespace Application.Features.Auth.Constants;

public static class AuthMessages
{
    public const string SectionName = "Auth";

    public const string EmailAuthenticatorDontExists = "EmailAuthenticatorDontExists";
    public const string OtpAuthenticatorDontExists = "OtpAuthenticatorDontExists";
    public const string AlreadyVerifiedOtpAuthenticatorIsExists = "AlreadyVerifiedOtpAuthenticatorIsExists";
    public const string EmailActivationKeyDontExists = "EmailActivationKeyDontExists";
    public const string UserDontExists = "User.DontExists";
    public const string UserHaveAlreadyAAuthenticator = "UserHaveAlreadyAAuthenticator";
    public const string RefreshDontExists = "RefreshDontExists";
    public const string InvalidRefreshToken = "InvalidRefreshToken";
    public const string UserMailAlreadyExists = "User.MailAlreadyExists";
    public const string PasswordDontMatch = "User.PasswordDontMatch";
    public const string ResetPasswordMailSent = "Reset Password Mail Sent";
    public const string UserEmailOrPasswordWrong = "User.EmailOrPasswordWrong";
    public const string EmailIsRequired = "User.EmailIsRequired";
    public const string PasswordIsRequired = "User.PasswordIsRequired";
    public const string CurrentPasswordIsInvalid = "User.CurrentPasswordIsInvalid";
    public const string PasswordTooShort = "User.PasswordTooShort";
    public const string PasswordTooLong = "User.PasswordTooLong";
    public const string NewPasswordShouldBeDifferent = "User.NewPasswordShouldBeDifferent";
}