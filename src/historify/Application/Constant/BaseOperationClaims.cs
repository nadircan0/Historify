namespace Application.Constants;

public static class BaseOperationClaims
{
    public const string Admin = "Admin";

    public const string User = "User";
    public static string[] AllRoles => [Admin, User];

    public static class Operations
    {
        public const string Read = "Read";
        public const string Write = "Write";
        public const string Create = "Create";
        public const string Update = "Update";
        public const string Delete = "Delete";
    }

    public static string[] GetOperationsForSection(string section)
    {
        return
        [
            $"{section}.{Operations.Read}",
            $"{section}.{Operations.Write}",
            $"{section}.{Operations.Create}",
            $"{section}.{Operations.Update}",
            $"{section}.{Operations.Delete}"
        ];
    }
}
