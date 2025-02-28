using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Inventory;

namespace SAX.Persistence.Configurations;

public class InventoryConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouses");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.WarehouseName).IsRequired().HasMaxLength(100);
            builder.HasOne(w => w.Address)
                .WithMany(a => a.Warehouses)
                .HasForeignKey(w => w.AddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.ToTable("ProductInventories");
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.QuantityOnHand).IsRequired();
            builder.Property(pi => pi.QuantityAvailable).IsRequired();
            builder.Property(pi => pi.LastStockUpdate).IsRequired();
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pi => pi.Warehouse)
                .WithMany(w => w.ProductInventories)
                .HasForeignKey(pi => pi.WarehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");
            builder.HasKey(sm => sm.Id);
            builder.Property(sm => sm.QuantityChanged).IsRequired();
            builder.Property(sm => sm.MovementType).IsRequired().HasMaxLength(50);
            builder.Property(sm => sm.MovementDate).IsRequired();
            builder.Property(sm => sm.Reason).HasMaxLength(500);
            builder.HasOne(sm => sm.ProductInventory)
                .WithMany(pi => pi.StockMovements)
                .HasForeignKey(sm => sm.ProductInventoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}