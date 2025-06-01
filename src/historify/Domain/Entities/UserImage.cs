using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserImage : Entity<Guid>
{
    public string Description { get; set; } = string.Empty;
    public DescriptionType DescriptionType { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Tags { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;

    public Guid FileAttachmentId { get; set; }
    public virtual FileAttachment FileAttachment { get; set; } = default!;

    public UserImage()
    {
        Description = string.Empty;
        DescriptionType = DescriptionType.MadeByMe;
        UploadDate = DateTime.Now;
        Tags = string.Empty;
    }

    public UserImage(
        Guid id,
        string description,
        DescriptionType descriptionType,
        DateTime uploadDate,
        string? tags,
        Guid userId,
        Guid fileAttachmentId
    )
    {
        Id = id;
        Description = description;
        DescriptionType = descriptionType;
        UploadDate = uploadDate;
        Tags = tags;
        UserId = userId;
        FileAttachmentId = fileAttachmentId;
    }
}
