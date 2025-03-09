using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations.ContentConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(c => c.CreatedByUser)
            .WithMany()
            .HasForeignKey(c => c.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.UpdatedByUser)
            .WithMany()
            .HasForeignKey(c => c.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.DeletedByUser)
            .WithMany()
            .HasForeignKey(c => c.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}