using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class FileAttachment : Entity<Guid>
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string StorageType { get; set; } // "Local" or "Azure" etc.

    public Guid? UserId { get; set; }
    public Guid? UserImageId { get; set; }

    public virtual UserImage? UserImage { get; set; }
    public virtual User? User { get; set; }

    //


}
