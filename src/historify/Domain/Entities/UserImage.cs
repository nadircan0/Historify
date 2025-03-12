using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserImage : Entity<Guid>
{
    
    public string Description { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Tags { get; set; }
    public virtual FileAttachment FileAttachment { get; set; } = default!;


} 