using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations.ProductsConfiguration;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(pc => pc.Id);

        builder.Property(pc => pc.CategoryName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(pc => pc.Description)
            .HasMaxLength(1000);

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