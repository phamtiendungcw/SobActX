using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Inventory;

namespace SAX.Persistence.Configurations.InventoryConfiguration;

public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
{
    public void Configure(EntityTypeBuilder<ProductInventory> builder)
    {
        builder.ToTable("ProductInventories");
        builder.HasKey(pi => pi.Id);

        builder.HasOne(pi => pi.Product)
            .WithMany(p => p.ProductInventories)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pi => pi.Warehouse)
            .WithMany(w => w.ProductInventories)
            .HasForeignKey(pi => pi.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pi => pi.CreatedByUser)
            .WithMany()
            .HasForeignKey(pi => pi.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pi => pi.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pi => pi.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pi => pi.DeletedByUser)
            .WithMany()
            .HasForeignKey(pi => pi.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}