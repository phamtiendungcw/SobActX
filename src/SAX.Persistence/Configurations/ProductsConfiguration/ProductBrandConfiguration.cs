using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations.ProductsConfiguration;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.ToTable("ProductBrands");
        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.BrandName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(pb => pb.Description)
            .HasMaxLength(1000);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pb => pb.CreatedByUser)
            .WithMany()
            .HasForeignKey(pb => pb.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pb => pb.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pb => pb.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pb => pb.DeletedByUser)
            .WithMany()
            .HasForeignKey(pb => pb.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}