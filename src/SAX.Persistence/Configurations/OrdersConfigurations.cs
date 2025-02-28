using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations;

public class OrdersConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.OrderStatus).IsRequired().HasMaxLength(50);
            builder.Property(o => o.PaymentMethod).IsRequired().HasMaxLength(50);
            builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)"); // Decimal precision
            builder.Property(o => o.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(o => o.ShippingCost).HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.ShippingAddress)
                .WithMany(a => a.ShippingOrders)
                .HasForeignKey(o => o.ShippingAddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.BillingAddress)
                .WithMany(a => a.BillingOrders)
                .HasForeignKey(o => o.BillingAddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(oi => oi.LineItemTotal).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Product
        }
    }

    public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
    {
        public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
        {
            builder.ToTable("OrderStatusHistories");
            builder.HasKey(osh => osh.Id);
            builder.Property(osh => osh.Status).IsRequired().HasMaxLength(50);
            builder.Property(osh => osh.StatusDate).IsRequired();
            builder.Property(osh => osh.Notes).HasMaxLength(500);

            builder.HasOne(osh => osh.Order)
                .WithMany(o => o.OrderStatusHistories)
                .HasForeignKey(osh => osh.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("PaymentTransactions");
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.TransactionDate).IsRequired();
            builder.Property(pt => pt.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(pt => pt.PaymentStatus).IsRequired().HasMaxLength(50);
            builder.Property(pt => pt.PaymentGatewayReference).HasMaxLength(255);

            builder.HasOne(pt => pt.Order)
                .WithMany(o => o.PaymentTransactions)
                .HasForeignKey(pt => pt.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts");
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.CreatedDate).IsRequired();
            builder.Property(sc => sc.LastModifiedDate).IsRequired();

            builder.HasOne(sc => sc.Customer)
                .WithOne(c => c.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItems");
            builder.HasKey(sci => sci.Id);
            builder.Property(sci => sci.Quantity).IsRequired();
            builder.Property(sci => sci.AddedDate).IsRequired();

            builder.HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sci => sci.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(sci => sci.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Product
        }
    }
}