using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserImage : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Tags { get; set; }
    public string StorageType { get; set; } // "Local" veya "Azure" gibi
    
    public virtual User User { get; set; } = default!;
} 