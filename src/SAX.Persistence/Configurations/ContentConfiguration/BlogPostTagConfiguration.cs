using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations.ContentConfiguration;

public class BlogPostTagConfiguration : IEntityTypeConfiguration<BlogPostTag>
{
    public void Configure(EntityTypeBuilder<BlogPostTag> builder)
    {
        builder.ToTable("BlogPostsTags");
        builder.HasKey(bpt => bpt.Id);

        builder.HasOne(bpt => bpt.BlogPost)
            .WithMany(bp => bp.BlogPostTags)
            .HasForeignKey(bpt => bpt.BlogPostId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bpt => bpt.Tag)
            .WithMany(t => t.BlogPostTags)
            .HasForeignKey(bpt => bpt.TagId)
            .OnDelete(DeleteBehavior.Restrict);

        // BaseEntity configuration (if needed)
        builder.HasOne(bpt => bpt.CreatedByUser)
            .WithMany()
            .HasForeignKey(bpt => bpt.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bpt => bpt.UpdatedByUser)
            .WithMany()
            .HasForeignKey(bpt => bpt.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bpt => bpt.DeletedByUser)
            .WithMany()
            .HasForeignKey(bpt => bpt.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}