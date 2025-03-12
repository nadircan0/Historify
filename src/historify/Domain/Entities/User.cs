namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string CountryCode { get; set; } 
    public string PhoneNumber { get; set; } 



    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;
    
    public virtual ICollection<FileAttachment> FileAttachments { get; set; } = new HashSet<FileAttachment>();
}
