using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations.ContentConfiguration;

public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts");
        builder.HasKey(bp => bp.Id);

        builder.Property(bp => bp.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(bp => bp.Slug)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(bp => bp.ContentBody)
            .HasColumnType("ntext");

        // Quan hệ với User (Author)
        builder.HasOne(bp => bp.Author)
            .WithMany(u => u.BlogPosts)
            .HasForeignKey(bp => bp.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Quan hệ với Category
        builder.HasOne(bp => bp.Category)
            .WithMany(c => c.BlogPosts)
            .HasForeignKey(bp => bp.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(bp => bp.CreatedByUser)
            .WithMany()
            .HasForeignKey(bp => bp.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bp => bp.UpdatedByUser)
            .WithMany()
            .HasForeignKey(bp => bp.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bp => bp.DeletedByUser)
            .WithMany()
            .HasForeignKey(bp => bp.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}