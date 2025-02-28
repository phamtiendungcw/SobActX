using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Logging;

namespace SAX.Persistence.Configurations;

public class LoggingConfigurations
{
    public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.ToTable("LogEntries");
            builder.HasKey(le => le.Id);
            builder.Property(le => le.Timestamp).IsRequired();
            builder.Property(le => le.LogLevel).IsRequired().HasMaxLength(20);
            builder.Property(le => le.Source).IsRequired().HasMaxLength(100);
            builder.Property(le => le.Message).IsRequired();
            builder.Property(le => le.Exception).HasMaxLength(2000);
            builder.HasOne(le => le.User)
                .WithMany(u => u.LogEntries)
                .HasForeignKey(le => le.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}