using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Promotions;

namespace SAX.Persistence.Configurations;

public class PromotionsConfigurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PromotionName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.PromotionType).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DiscountValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.CouponCode).HasMaxLength(50);
            builder.Property(p => p.MinimumOrderValue).HasColumnType("decimal(18,2)");
        }
    }

    public class PromotionProductConfiguration : IEntityTypeConfiguration<PromotionProduct>
    {
        public void Configure(EntityTypeBuilder<PromotionProduct> builder)
        {
            builder.ToTable("PromotionProducts");
            builder.HasKey(pp => pp.Id);

            builder.HasOne(pp => pp.Promotion)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.PromotionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.PromotionProducts)
                .HasForeignKey(pp => pp.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Product
        }
    }

    public class PromotionCategoryConfiguration : IEntityTypeConfiguration<PromotionCategory>
    {
        public void Configure(EntityTypeBuilder<PromotionCategory> builder)
        {
            builder.ToTable("PromotionCategories");
            builder.HasKey(pc => pc.Id);

            builder.HasOne(pc => pc.Promotion)
                .WithMany(p => p.PromotionCategories)
                .HasForeignKey(pc => pc.PromotionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.ProductCategory)
                .WithMany(p => p.PromotionCategories)
                .HasForeignKey(pc => pc.ProductCategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on ProductCategory
        }
    }
}