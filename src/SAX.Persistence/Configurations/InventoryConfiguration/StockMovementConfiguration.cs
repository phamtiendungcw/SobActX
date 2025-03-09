using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Inventory;

namespace SAX.Persistence.Configurations.InventoryConfiguration;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("StockMovements");
        builder.HasKey(sm => sm.Id);

        builder.Property(sm => sm.MovementType)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(sm => sm.Reason)
            .HasMaxLength(255);

        builder.HasOne(sm => sm.ProductInventory)
            .WithMany(pi => pi.StockMovements)
            .HasForeignKey(sm => sm.ProductInventoryId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa StockMovement khi ProductInventory bị xóa

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(sm => sm.CreatedByUser)
            .WithMany()
            .HasForeignKey(sm => sm.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sm => sm.UpdatedByUser)
            .WithMany()
            .HasForeignKey(sm => sm.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sm => sm.DeletedByUser)
            .WithMany()
            .HasForeignKey(sm => sm.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}