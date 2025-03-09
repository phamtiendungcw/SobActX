using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Inventory;

namespace SAX.Persistence.Configurations.InventoryConfiguration;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.WarehouseName)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(w => w.Address)
            .WithMany(a => a.Warehouses)
            .HasForeignKey(w => w.AddressId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Address thì set AddressId của Warehouse thành null

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(w => w.CreatedByUser)
            .WithMany()
            .HasForeignKey(w => w.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.UpdatedByUser)
            .WithMany()
            .HasForeignKey(w => w.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.DeletedByUser)
            .WithMany()
            .HasForeignKey(w => w.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}