using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Marketing;

namespace SAX.Persistence.Configurations.MarketingConfiguration;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CampaignName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.TargetAudience)
            .HasMaxLength(255);

        builder.Property(c => c.Budget)
            .HasColumnType("decimal(18, 2)");

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