using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;
using Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        // Configuring the table
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        // Adding query filter to exclude soft-deleted records
        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        // Relationships
        builder.HasOne(uoc => uoc.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uoc => uoc.UserId);

        builder.HasOne(uoc => uoc.OperationClaim).WithMany().HasForeignKey(uoc => uoc.OperationClaimId);

        // Seed data
        builder.HasData(GetSeeds());
    }

    private IEnumerable<UserOperationClaim> GetSeeds()
    {
        return new List<UserOperationClaim>
        {
            new UserOperationClaim
            {
                Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), // Sabit GUID
                UserId = UserConfiguration.AdminId,
                OperationClaimId = OperationClaimConfiguration.AdminId,
                CreatedDate = new DateTime(2024, 1, 1)
            },
            new UserOperationClaim
            {
                Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), // Sabit GUID
                UserId = UserConfiguration.UserId,
                OperationClaimId = OperationClaimConfiguration.UserId,
                CreatedDate = new DateTime(2024, 1, 1)
            },
        };
    }
}
