namespace Domain.Entities;

public class UserOperationClaim : NArchitecture.Core.Security.Entities.UserOperationClaim<Guid, Guid, Guid>
{
    public virtual User User { get; set; } = default!;
    public virtual OperationClaim OperationClaim { get; set; } = default!;
}
