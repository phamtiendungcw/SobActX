using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations;

public class ContentConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
        }
    }

    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TagName).IsRequired().HasMaxLength(50);
        }
    }

    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ContentBody).IsRequired();
            builder.Property(p => p.PublishDate).IsRequired();
            builder.HasOne(p => p.Author).WithMany(u => u.Pages).HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("BlogPosts");
            builder.HasKey(bp => bp.Id);
            builder.Property(bp => bp.Title).IsRequired().HasMaxLength(200);
            builder.Property(bp => bp.Slug).IsRequired().HasMaxLength(200);
            builder.Property(bp => bp.ContentBody).IsRequired();
            builder.Property(bp => bp.PublishDate).IsRequired();
            builder.HasOne(bp => bp.Author).WithMany(u => u.BlogPosts).HasForeignKey(bp => bp.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bp => bp.Category).WithMany(c => c.BlogPosts).HasForeignKey(bp => bp.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bp => bp.Tags)
                .WithMany(t => t.BlogPosts)
                .UsingEntity(j => j.ToTable("BlogPostTags"));
        }
    }

    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FileName).IsRequired().HasMaxLength(255);
            builder.Property(m => m.FilePath).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.MediaType).IsRequired().HasMaxLength(50);
            builder.Property(m => m.UploadDate).IsRequired();
        }
    }
}