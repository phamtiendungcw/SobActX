using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Promotions;

namespace SAX.Persistence.Configurations.PromotionsConfiguration;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.ToTable("Promotions");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PromotionName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.PromotionType)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(p => p.DiscountValue)
            .HasColumnType("decimal(18, 2)");

        builder.Property(p => p.CouponCode)
            .HasMaxLength(50);

        builder.Property(p => p.MinimumOrderValue)
            .HasColumnType("decimal(18, 2)");
        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(p => p.CreatedByUser)
            .WithMany()
            .HasForeignKey(p => p.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.UpdatedByUser)
            .WithMany()
            .HasForeignKey(p => p.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.DeletedByUser)
            .WithMany()
            .HasForeignKey(p => p.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}