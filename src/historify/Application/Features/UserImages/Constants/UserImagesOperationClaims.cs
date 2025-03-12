namespace Application.Features.UserImages.Constants;

public static class UserImagesOperationClaims
{
    private const string _section = "UserImages";

    public const string Admin = $"Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}