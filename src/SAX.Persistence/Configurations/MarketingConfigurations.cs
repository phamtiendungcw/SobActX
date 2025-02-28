using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Marketing;

namespace SAX.Persistence.Configurations;

public class MarketingConfigurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaigns");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CampaignName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired(false);
            builder.Property(c => c.TargetAudience).HasMaxLength(500);
            builder.Property(c => c.Budget).IsRequired(false);
        }
    }

    public class EmailCampaignConfiguration : IEntityTypeConfiguration<EmailCampaign>
    {
        public void Configure(EntityTypeBuilder<EmailCampaign> builder)
        {
            builder.ToTable("EmailCampaigns");
            builder.HasKey(ec => ec.Id);
            builder.HasOne(ec => ec.Campaign)
                .WithMany(c => c.EmailCampaigns)
                .HasForeignKey(ec => ec.CampaignId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ec => ec.EmailTemplate)
                .WithMany(et => et.EmailCampaigns)
                .HasForeignKey(ec => ec.EmailTemplateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on EmailTemplate
            builder.HasOne(ec => ec.Segment)
                .WithMany(s => s.EmailCampaigns)
                .HasForeignKey(ec => ec.SegmentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Segment
        }
    }

    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.ToTable("Segments");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SegmentName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Criteria).HasMaxLength(1000);
        }
    }

    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ToTable("EmailTemplates");
            builder.HasKey(et => et.Id);
            builder.Property(et => et.TemplateName).IsRequired().HasMaxLength(100);
            builder.Property(et => et.Subject).IsRequired().HasMaxLength(200);
            builder.Property(et => et.Body).IsRequired();
        }
    }
}