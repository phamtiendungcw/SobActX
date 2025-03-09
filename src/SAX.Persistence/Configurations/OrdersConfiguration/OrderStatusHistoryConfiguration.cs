using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
    {
        builder.ToTable("OrderStatusHistories");
        builder.HasKey(osh => osh.Id);

        builder.Property(osh => osh.Status)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(osh => osh.Notes)
            .HasMaxLength(255);

        builder.HasOne(osh => osh.Order)
            .WithMany(o => o.OrderStatusHistories)
            .HasForeignKey(osh => osh.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa OrderStatusHistory khi Order bị xóa

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(osh => osh.CreatedByUser)
            .WithMany()
            .HasForeignKey(osh => osh.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(osh => osh.UpdatedByUser)
            .WithMany()
            .HasForeignKey(osh => osh.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(osh => osh.DeletedByUser)
            .WithMany()
            .HasForeignKey(osh => osh.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}