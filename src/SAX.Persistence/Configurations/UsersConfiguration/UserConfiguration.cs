using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Users;

namespace SAX.Persistence.Configurations.UsersConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(255);
        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(255);
    }
}