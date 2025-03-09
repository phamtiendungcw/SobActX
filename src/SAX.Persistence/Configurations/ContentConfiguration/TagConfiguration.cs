using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations.ContentConfiguration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.TagName)
            .IsRequired()
            .HasMaxLength(255);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(t => t.CreatedByUser)
            .WithMany()
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.UpdatedByUser)
            .WithMany()
            .HasForeignKey(t => t.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.DeletedByUser)
            .WithMany()
            .HasForeignKey(t => t.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}