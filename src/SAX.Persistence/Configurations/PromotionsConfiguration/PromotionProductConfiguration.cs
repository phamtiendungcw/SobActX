using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Promotions;

namespace SAX.Persistence.Configurations.PromotionsConfiguration;

public class PromotionProductConfiguration : IEntityTypeConfiguration<PromotionProduct>
{
    public void Configure(EntityTypeBuilder<PromotionProduct> builder)
    {
        builder.ToTable("PromotionsProducts");
        builder.HasKey(pp => pp.Id);

        builder.HasOne(pp => pp.Promotion)
            .WithMany(p => p.PromotionProducts)
            .HasForeignKey(pp => pp.PromotionId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa PromotionProduct khi Promotion bị xóa

        builder.HasOne(pp => pp.Product)
            .WithMany(p => p.PromotionProducts)
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pp => pp.CreatedByUser)
            .WithMany()
            .HasForeignKey(pp => pp.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pp => pp.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pp => pp.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pp => pp.DeletedByUser)
            .WithMany()
            .HasForeignKey(pp => pp.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}