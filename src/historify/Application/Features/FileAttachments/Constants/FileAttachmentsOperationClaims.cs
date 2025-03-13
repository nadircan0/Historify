namespace Application.Features.FileAttachments.Constants;

public static class FileAttachmentsOperationClaims
{
    private const string _section = "FileAttachments";

    public const string Admin = $"Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}
