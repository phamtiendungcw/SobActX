using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Logging;

namespace SAX.Persistence.Configurations.LoggingConfiguration;

public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
{
    public void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        builder.ToTable("LogEntries");
        builder.HasKey(le => le.Id);

        builder.Property(le => le.LogLevel)
            .IsRequired()
            .HasConversion<string>(); // Lưu enum dưới dạng string

        builder.Property(le => le.Source)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(le => le.Message)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(le => le.Exception)
            .HasColumnType("ntext");

        builder.HasOne(le => le.User)
            .WithMany(u => u.LogEntries)
            .HasForeignKey(le => le.UserId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa User thì set UserId của LogEntry thành null

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(le => le.CreatedByUser)
            .WithMany()
            .HasForeignKey(le => le.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(le => le.UpdatedByUser)
            .WithMany()
            .HasForeignKey(le => le.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(le => le.DeletedByUser)
            .WithMany()
            .HasForeignKey(le => le.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}