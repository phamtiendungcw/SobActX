using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations;

public class ProductsConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.SKU).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageUrl).HasMaxLength(1000);

            builder.HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on ProductCategory

            builder.HasOne(p => p.Brand)
                .WithMany(pb => pb.Products)
                .HasForeignKey(p => p.BrandId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on ProductBrand
        }
    }

    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(pc => pc.Description).HasMaxLength(500);
        }
    }

    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("ProductBrands");
            builder.HasKey(pb => pb.Id);
            builder.Property(pb => pb.BrandName).IsRequired().HasMaxLength(100);
            builder.Property(pb => pb.Description).HasMaxLength(500);
        }
    }

    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("ProductAttributes");
            builder.HasKey(pa => pa.Id);
            builder.Property(pa => pa.AttributeName).IsRequired().HasMaxLength(100);
        }
    }

    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.ToTable("ProductAttributeValues");
            builder.HasKey(pav => pav.Id);
            builder.Property(pav => pav.Value).IsRequired().HasMaxLength(255);

            builder.HasOne(pav => pav.Product)
                .WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(pav => pav.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pav => pav.ProductAttribute)
                .WithMany(pa => pa.ProductAttributeValues)
                .HasForeignKey(pav => pav.ProductAttributeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on ProductAttribute
        }
    }

    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReviews");
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Rating).IsRequired();
            builder.Property(pr => pr.Comment).HasMaxLength(1000);
            builder.Property(pr => pr.ReviewDate).IsRequired();
            builder.Property(pr => pr.IsApproved).IsRequired(); // Assuming IsApproved is required

            builder.HasOne(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pr => pr.Customer)
                .WithMany(c => c.ProductReviews)
                .HasForeignKey(pr => pr.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Customer
        }
    }
}