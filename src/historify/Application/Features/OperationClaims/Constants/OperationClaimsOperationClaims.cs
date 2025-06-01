using Application.Constants;

namespace Application.Features.OperationClaims.Constants;

public static class OperationClaimsOperationClaims
{
    private const string _section = "OperationClaims";

    // Base Roles
    public const string Admin = BaseOperationClaims.Admin;
    public const string User = BaseOperationClaims.User;

    // Operations
    public const string Read = $"{_section}.{BaseOperationClaims.Operations.Read}";
    public const string Write = $"{_section}.{BaseOperationClaims.Operations.Write}";
    public const string Create = $"{_section}.{BaseOperationClaims.Operations.Create}";
    public const string Update = $"{_section}.{BaseOperationClaims.Operations.Update}";
    public const string Delete = $"{_section}.{BaseOperationClaims.Operations.Delete}";
}
