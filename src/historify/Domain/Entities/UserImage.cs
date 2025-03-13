using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserImage : Entity<Guid>
{
    public string Description { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Tags { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;

    public Guid FileAttachmentId { get; set; }
    public virtual FileAttachment FileAttachment { get; set; } = default!;
}
