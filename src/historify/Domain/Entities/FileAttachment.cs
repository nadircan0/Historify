using System;
using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class FileAttachment : Entity<Guid>
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty; //PathOrContainerName
    public StorageType StorageType { get; set; } = StorageType.Azure; // "Local" or "Azure" etc.
    public DateTime UploadDate { get; set; } = DateTime.Now;

    public Guid? UserImageId { get; set; }
    public virtual UserImage? UserImage { get; set; }
}
