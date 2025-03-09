using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Content;

namespace SAX.Persistence.Configurations.ContentConfiguration;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("Media");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(m => m.FilePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.MediaType)
            .IsRequired()
            .HasMaxLength(255);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(m => m.CreatedByUser)
            .WithMany()
            .HasForeignKey(m => m.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.UpdatedByUser)
            .WithMany()
            .HasForeignKey(m => m.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.DeletedByUser)
            .WithMany()
            .HasForeignKey(m => m.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}