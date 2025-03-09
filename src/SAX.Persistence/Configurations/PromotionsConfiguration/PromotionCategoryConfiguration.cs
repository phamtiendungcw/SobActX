using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Promotions;

namespace SAX.Persistence.Configurations.PromotionsConfiguration;

public class PromotionCategoryConfiguration : IEntityTypeConfiguration<PromotionCategory>
{
    public void Configure(EntityTypeBuilder<PromotionCategory> builder)
    {
        builder.ToTable("PromotionsCategories");
        builder.HasKey(pc => pc.Id);

        builder.HasOne(pc => pc.Promotion)
            .WithMany(p => p.PromotionsCategories)
            .HasForeignKey(pc => pc.PromotionId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa PromotionCategory khi Promotion bị xóa

        builder.HasOne(pc => pc.ProductCategory)
            .WithMany(c => c.PromotionsCategories)
            .HasForeignKey(pc => pc.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pc => pc.CreatedByUser)
            .WithMany()
            .HasForeignKey(pc => pc.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pc => pc.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pc => pc.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pc => pc.DeletedByUser)
            .WithMany()
            .HasForeignKey(pc => pc.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}