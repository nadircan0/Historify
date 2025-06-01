using Application.Constants;

namespace Application.Features.Auth.Constants;

public static class AuthOperationClaims
{
    private const string _section = "Auth";

    // Base Roles
    public const string Admin = BaseOperationClaims.Admin;
    public const string User = BaseOperationClaims.User;

    // Operations
    public const string Read = $"{_section}.{BaseOperationClaims.Operations.Read}";
    public const string Write = $"{_section}.{BaseOperationClaims.Operations.Write}";
    public const string Create = $"{_section}.{BaseOperationClaims.Operations.Create}";
    public const string Update = $"{_section}.{BaseOperationClaims.Operations.Update}";
    public const string Delete = $"{_section}.{BaseOperationClaims.Operations.Delete}";

    // Extra Auth Operations
    public const string Login = $"{_section}.Login";
    public const string Register = $"{_section}.Register";
    public const string RevokeToken = $"{_section}.RevokeToken";
}
