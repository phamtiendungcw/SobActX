using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Users;

namespace SAX.Persistence.Configurations.UsersConfiguration;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolesPermissions");
        builder.HasKey(rp => rp.Id);

        builder.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa RolePermission khi Role bị xóa

        builder.HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(rp => rp.CreatedByUser)
            .WithMany()
            .HasForeignKey(rp => rp.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rp => rp.UpdatedByUser)
            .WithMany()
            .HasForeignKey(rp => rp.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rp => rp.DeletedByUser)
            .WithMany()
            .HasForeignKey(rp => rp.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}