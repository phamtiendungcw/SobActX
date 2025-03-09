using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Marketing;

namespace SAX.Persistence.Configurations.MarketingConfiguration;

public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
{
    public void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        builder.ToTable("EmailTemplates");
        builder.HasKey(et => et.Id);

        builder.Property(et => et.TemplateName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(et => et.Subject)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(et => et.Body)
            .HasColumnType("ntext");

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(et => et.CreatedByUser)
            .WithMany()
            .HasForeignKey(et => et.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(et => et.UpdatedByUser)
            .WithMany()
            .HasForeignKey(et => et.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(et => et.DeletedByUser)
            .WithMany()
            .HasForeignKey(et => et.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}