using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings;

public class UserMap : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);

        // Indexes for "normalized" username and email, to allow efficient lookups
        builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

        // Maps to the AspNetUsers table
        builder.ToTable("AspNetUsers");

        // A concurrency token for use with the optimistic concurrency checking
        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        builder.Property(u => u.UserName).HasMaxLength(256);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

        // The relationships between User and other entity types
        // Note that these relationships are configured with no navigation properties

        // Each User can have many UserClaims
        builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

        // Each User can have many UserLogins
        builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

        // Each User can have many UserTokens
        builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

        // Each User can have many entries in the UserRole join table
        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

        var superadmin = new AppUser
        {
            Id = Guid.Parse("002CAE81-05C5-4534-82B9-F339BCA8E5B3"),
            UserName = "superadmin@gmail.com",
            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
            Email = "superadmin@gmail.com",
            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
            PhoneNumber = "+905431234578",
            FirstName = "Can",
            LastName = "Keskin",
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId = Guid.Parse("35AC5F88-8C37-4136-8067-3906E39D8B51")
        };
        superadmin.PasswordHash = CreatePasswordHash(superadmin,"123456");

        var admin = new AppUser
        {
            Id = Guid.Parse("1F51BBD1-312C-44FE-98EA-203E1C17EE5A"),
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            PhoneNumber = "+905431236668",
            FirstName = "Admin",
            LastName = "User",
            PhoneNumberConfirmed = false,
            EmailConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId = Guid.Parse("EBAEBC76-3FFB-47E7-A424-C4D0F3313EC5")
        };
        admin.PasswordHash = CreatePasswordHash(admin, "123456");

        builder.HasData(superadmin, admin);

    }
    private string CreatePasswordHash(AppUser user, string password)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.HashPassword(user, password);
    }
}
