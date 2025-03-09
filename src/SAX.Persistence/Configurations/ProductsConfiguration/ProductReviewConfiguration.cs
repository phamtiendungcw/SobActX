using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Products;

namespace SAX.Persistence.Configurations.ProductsConfiguration;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.ToTable("ProductReviews");
        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Rating)
            .HasAnnotation("Range", new[] { 1, 5 }); // Giả sử thang điểm 5 sao

        builder.Property(pr => pr.Comment)
            .HasMaxLength(1000);

        builder.HasOne(pr => pr.Product)
            .WithMany(p => p.ProductReviews)
            .HasForeignKey(pr => pr.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pr => pr.Customer)
            .WithMany(c => c.ProductReviews)
            .HasForeignKey(pr => pr.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(pr => pr.CreatedByUser)
            .WithMany()
            .HasForeignKey(pr => pr.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pr => pr.UpdatedByUser)
            .WithMany()
            .HasForeignKey(pr => pr.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pr => pr.DeletedByUser)
            .WithMany()
            .HasForeignKey(pr => pr.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}