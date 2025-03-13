using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        // Sabit ve benzersiz GUID'ler
        public static Guid AdminId { get; } = new Guid("00000000-0000-0000-0000-000000000001");
        public static Guid UserId { get; } = new Guid("00000000-0000-0000-0000-000000000002");
        public static Guid DemoUserId { get; } = new Guid("00000000-0000-0000-0000-000000000003");

        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id)
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(oc => oc.Name)
                   .HasColumnName("Name")
                   .IsRequired();

            builder.Property(oc => oc.CreatedDate)
                   .HasColumnName("CreatedDate")
                   .IsRequired();

            builder.Property(oc => oc.UpdatedDate)
                   .HasColumnName("UpdatedDate");

            builder.Property(oc => oc.DeletedDate)
                   .HasColumnName("DeletedDate");

            // Global Query Filter to exclude soft-deleted records
            builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

            // Seed data
            builder.HasData(GetSeeds());
        }

        private IEnumerable<OperationClaim> GetSeeds()
        {
            return new List<OperationClaim>
            {
                new OperationClaim
                {
                    Id = AdminId,
                    Name = "Admin",
                    CreatedDate = new DateTime(2024, 1, 1)
                },
                new OperationClaim
                {
                    Id = UserId,
                    Name = "User",
                    CreatedDate = new DateTime(2024, 1, 1)
                },
                new OperationClaim
                {
                    Id = DemoUserId,
                    Name = "DemoUser",
                    CreatedDate = new DateTime(2024, 1, 1)
                }
            };
        }
    }
}
