using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FileAttachmentConfiguration : IEntityTypeConfiguration<FileAttachment>
{
    public void Configure(EntityTypeBuilder<FileAttachment> builder)
    {
        builder.ToTable("FileAttachments").HasKey(fa => fa.Id);

        builder.Property(fa => fa.Id).HasColumnName("Id").IsRequired();
        builder.Property(fa => fa.FileName).HasColumnName("FileName").IsRequired();
        builder.Property(fa => fa.FilePath).HasColumnName("FilePath").IsRequired();
        builder.Property(fa => fa.StorageType).HasColumnName("StorageType").IsRequired();
        builder.Property(fa => fa.UserId).HasColumnName("UserId");
        builder.Property(fa => fa.UserImageId).HasColumnName("UserImageId");
        builder.Property(fa => fa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fa => fa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fa => fa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(fa => !fa.DeletedDate.HasValue);
    }
}
