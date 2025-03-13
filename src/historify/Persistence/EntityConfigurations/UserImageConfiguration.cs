using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
{
    public void Configure(EntityTypeBuilder<UserImage> builder)
    {
        builder.ToTable("UserImages").HasKey(ui => ui.Id);

        builder.Property(ui => ui.Id).HasColumnName("Id").IsRequired();
        builder.Property(ui => ui.Description).HasColumnName("Description").IsRequired();
        builder.Property(ui => ui.UploadDate).HasColumnName("UploadDate").IsRequired();
        builder.Property(ui => ui.Tags).HasColumnName("Tags");
        builder.Property(ui => ui.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ui => ui.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ui => ui.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ui => ui.User).WithMany(u => u.UserImages).HasForeignKey(ui => ui.UserId);
        builder.HasOne(ui => ui.FileAttachment).WithOne(fa => fa.UserImage).HasForeignKey<FileAttachment>(fa => fa.UserImageId);

        builder.HasQueryFilter(ui => !ui.DeletedDate.HasValue);
    }
}
