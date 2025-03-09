using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
    {
        builder.ToTable("PaymentTransactions");
        builder.HasKey(pt => pt.Id);

        builder.Property(pt => pt.Amount)
            .HasColumnType("decimal(18, 2)");

        builder.Property(pt => pt.PaymentStatus)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(pt => pt.PaymentGatewayReference)
            .HasMaxLength(255);

        builder.HasOne(pt => pt.Order)
            .WithMany(o => o.PaymentTransactions)
            .HasForeignKey(pt => pt.OrderId)
            .OnDelete(DeleteBehavior.Restrict); // Không xóa PaymentTransaction khi Order bị xóa

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pt => pt.CreatedByUser)
            .WithMany()
            .HasForeignKey(pt => pt.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pt => pt.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pt => pt.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pt => pt.DeletedByUser)
            .WithMany()
            .HasForeignKey(pt => pt.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}