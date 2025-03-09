using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Users;

namespace SAX.Persistence.Configurations.UsersConfiguration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UsersRoles");
        builder.HasKey(ur => ur.Id);

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa UserRole khi User bị xóa

        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(ur => ur.CreatedByUser)
            .WithMany()
            .HasForeignKey(ur => ur.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ur => ur.UpdatedByUser)
            .WithMany()
            .HasForeignKey(ur => ur.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ur => ur.DeletedByUser)
            .WithMany()
            .HasForeignKey(ur => ur.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}