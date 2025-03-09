using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.UnitPrice)
            .HasColumnType("decimal(18, 2)");

        builder.Property(oi => oi.LineItemTotal)
            .HasColumnType("decimal(18, 2)");

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa OrderItem khi Order bị xóa

        builder.HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(oi => oi.CreatedByUser)
            .WithMany()
            .HasForeignKey(oi => oi.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(oi => oi.UpdatedByUser)
            .WithMany()
            .HasForeignKey(oi => oi.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(oi => oi.DeletedByUser)
            .WithMany()
            .HasForeignKey(oi => oi.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}