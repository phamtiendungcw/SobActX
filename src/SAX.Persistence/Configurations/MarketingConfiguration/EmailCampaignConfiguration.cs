using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Marketing;

namespace SAX.Persistence.Configurations.MarketingConfiguration;

public class EmailCampaignConfiguration : IEntityTypeConfiguration<EmailCampaign>
{
    public void Configure(EntityTypeBuilder<EmailCampaign> builder)
    {
        builder.ToTable("EmailCampaigns");
        builder.HasKey(ec => ec.Id);

        builder.HasOne(ec => ec.Campaign)
            .WithMany(c => c.EmailCampaigns)
            .HasForeignKey(ec => ec.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ec => ec.EmailTemplate)
            .WithMany(et => et.EmailCampaigns)
            .HasForeignKey(ec => ec.EmailTemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ec => ec.Segment)
            .WithMany(s => s.EmailCampaigns)
            .HasForeignKey(ec => ec.SegmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(ec => ec.CreatedByUser)
            .WithMany()
            .HasForeignKey(ec => ec.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ec => ec.UpdatedByUser)
            .WithMany()
            .HasForeignKey(ec => ec.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ec => ec.DeletedByUser)
            .WithMany()
            .HasForeignKey(ec => ec.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}