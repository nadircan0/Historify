using Domain.Entities;
using NArchitecture.Core.Test.Application.FakeData;

namespace StarterProject.Application.Tests.Mocks.FakeDatas;

public class OperationClaimFakeData : BaseFakeData<OperationClaim, Guid>
{
    public override List<OperationClaim> CreateFakeData()
    {
        return
        [
            new() { Id = Guid.NewGuid(), Name = "Admin" },
            new() { Id = Guid.NewGuid(), Name = "Example.Create" },
            new() { Id = Guid.NewGuid(), Name = "Example.Delete" },
            new() { Id = Guid.NewGuid(), Name = "Example.Update" },
            new() { Id = Guid.NewGuid(), Name = "Moderator" },
        ];
    }
}
