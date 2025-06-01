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
        builder.Property(fa => fa.FileName).HasColumnName("FileName").IsRequired().HasMaxLength(500);
        builder.Property(fa => fa.FilePath).HasColumnName("FilePath").IsRequired().HasMaxLength(500);
        builder.Property(fa => fa.StorageType).HasColumnName("StorageType").IsRequired();
        builder.Property(fa => fa.UploadDate).HasColumnName("UploadDate").IsRequired();
        builder.Property(fa => fa.UserImageId).HasColumnName("UserImageId").IsRequired();
        builder.Property(fa => fa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fa => fa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fa => fa.DeletedDate).HasColumnName("DeletedDate");

        // Relationships
        builder
            .HasOne(fa => fa.UserImage)
            .WithOne(ui => ui.FileAttachment)
            .HasForeignKey<FileAttachment>(fa => fa.UserImageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(fa => !fa.DeletedDate.HasValue);
    }
}
