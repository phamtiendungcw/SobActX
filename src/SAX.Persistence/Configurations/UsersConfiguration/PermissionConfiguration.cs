using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Users;

namespace SAX.Persistence.Configurations.UsersConfiguration;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PermissionName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(p => p.CreatedByUser)
            .WithMany()
            .HasForeignKey(p => p.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.UpdatedByUser)
            .WithMany()
            .HasForeignKey(p => p.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.DeletedByUser)
            .WithMany()
            .HasForeignKey(p => p.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}