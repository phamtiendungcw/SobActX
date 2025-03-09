using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations.ProductsConfiguration;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes");
        builder.HasKey(pa => pa.Id);

        builder.Property(pa => pa.AttributeName)
            .IsRequired()
            .HasMaxLength(255);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pa => pa.CreatedByUser)
            .WithMany()
            .HasForeignKey(pa => pa.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pa => pa.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pa => pa.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pa => pa.DeletedByUser)
            .WithMany()
            .HasForeignKey(pa => pa.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}