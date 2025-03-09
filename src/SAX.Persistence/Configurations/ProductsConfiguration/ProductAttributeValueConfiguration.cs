using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations.ProductsConfiguration;

public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.ToTable("ProductAttributeValues");
        builder.HasKey(pav => pav.Id);

        builder.Property(pav => pav.Value)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(pav => pav.Product)
            .WithMany(p => p.ProductAttributeValues)
            .HasForeignKey(pav => pav.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa ProductAttributeValue khi Product bị xóa

        builder.HasOne(pav => pav.ProductAttribute)
            .WithMany(pa => pa.ProductAttributeValues)
            .HasForeignKey(pav => pav.ProductAttributeId)
            .OnDelete(DeleteBehavior.Restrict);
        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pav => pav.CreatedByUser)
            .WithMany()
            .HasForeignKey(pav => pav.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pav => pav.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pav => pav.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pav => pav.DeletedByUser)
            .WithMany()
            .HasForeignKey(pav => pav.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}