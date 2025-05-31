namespace Application.Features.Auth.Commands.ChangePassword;

public class ChangePasswordResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public ChangePasswordResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
} 