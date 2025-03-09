using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Marketing;

namespace SAX.Persistence.Configurations.MarketingConfiguration;

public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
{
    public void Configure(EntityTypeBuilder<Segment> builder)
    {
        builder.ToTable("Segments");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SegmentName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(s => s.Criteria)
            .HasColumnType("ntext");

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(s => s.CreatedByUser)
            .WithMany()
            .HasForeignKey(s => s.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.UpdatedByUser)
            .WithMany()
            .HasForeignKey(s => s.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.DeletedByUser)
            .WithMany()
            .HasForeignKey(s => s.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}