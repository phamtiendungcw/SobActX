using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderStatus)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(o => o.PaymentMethod)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(o => o.TotalAmount)
            .HasColumnType("decimal(18, 2)");

        builder.Property(o => o.DiscountAmount)
            .HasColumnType("decimal(18, 2)");

        builder.Property(o => o.ShippingCost)
            .HasColumnType("decimal(18, 2)");

        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.ShippingAddress)
            .WithMany(a => a.ShippingOrders)
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Address thì set ShippingAddressId thành null

        builder.HasOne(o => o.BillingAddress)
            .WithMany(a => a.BillingOrders)
            .HasForeignKey(o => o.BillingAddressId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Address thì set BillingAddressId thành null

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(o => o.CreatedByUser)
            .WithMany()
            .HasForeignKey(o => o.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.UpdatedByUser)
            .WithMany()
            .HasForeignKey(o => o.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.DeletedByUser)
            .WithMany()
            .HasForeignKey(o => o.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}