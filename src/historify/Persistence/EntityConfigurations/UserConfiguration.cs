using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
        builder.Property(u => u.Surname).HasColumnName("Surname").IsRequired();
        builder.Property(u => u.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(u => u.CountryCode).HasColumnName("CountryCode").IsRequired();
        builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);
        builder.HasMany(u => u.FileAttachments);

        builder.HasData(GetSeeds());
    }

    public static Guid AdminId { get; } = new Guid("11111111-1111-1111-1111-111111111111");
    public static Guid UserId { get; } = new Guid("22222222-2222-2222-2222-222222222222");
    public static Guid DemoUserId { get; } = new Guid("33333333-3333-3333-3333-333333333333");

    // Yeni Admin (Kaan)
    public static Guid NadirAdminId { get; } = new Guid("44444444-4444-4444-4444-444444444444");

    private IEnumerable<User> GetSeeds()
    {
        // 1) Admin Kullanıcı
        HashingHelper.CreatePasswordHash("AdminPass123!", out byte[] adminHash, out byte[] adminSalt);
        yield return new User
        {
            Id = AdminId,
            Email = "admin@domain.com",
            PasswordHash = adminHash,
            PasswordSalt = adminSalt,
            AuthenticatorType = 0,
            CreatedDate = new DateTime(2024, 1, 1),
            Name = "Admin",
            Surname = "User",
            UserName = "admin",
            CountryCode = "+90",
            PhoneNumber = "5555555555"
        };

        // 2) Standard User
        HashingHelper.CreatePasswordHash("UserPass123!", out byte[] userHash, out byte[] userSalt);
        yield return new User
        {
            Id = UserId,
            Email = "user@domain.com",
            PasswordHash = userHash,
            PasswordSalt = userSalt,
            AuthenticatorType = 0,
            CreatedDate = new DateTime(2024, 1, 1),
            Name = "Standard",
            Surname = "User",
            UserName = "user",
            CountryCode = "+90",
            PhoneNumber = "5555555556"
        };

        // 3) Demo User
        HashingHelper.CreatePasswordHash("DemoPass123!", out byte[] demoHash, out byte[] demoSalt);
        yield return new User
        {
            Id = DemoUserId,
            Email = "demo@domain.com",
            PasswordHash = demoHash,
            PasswordSalt = demoSalt,
            AuthenticatorType = 0,
            CreatedDate = new DateTime(2024, 1, 1),
            Name = "Demo",
            Surname = "User",
            UserName = "demo",
            CountryCode = "+90",
            PhoneNumber = "5555555557"
        };

        // 4) Yeni Admin (nadircandegirmendere@gmail.com)
        HashingHelper.CreatePasswordHash("NadirPass123!", out byte[] nadirHash, out byte[] nadirSalt);
        yield return new User
        {
            Id = NadirAdminId,
            Email = "nadircandegirmendere@gmail.com",
            PasswordHash = nadirHash,
            PasswordSalt = nadirSalt,
            AuthenticatorType = 0,
            CreatedDate = new DateTime(2025, 1, 1),
            Name = "Nadir can",
            Surname = "Degirmendere",
            UserName = "cansnow",
            CountryCode = "+90",
            PhoneNumber = "5555555558"
        };
    }
}