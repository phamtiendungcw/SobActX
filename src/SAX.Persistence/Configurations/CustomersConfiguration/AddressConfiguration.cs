using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Customers;

namespace SAX.Persistence.Configurations.CustomersConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.StreetAddress)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.State)
            .HasMaxLength(50);

        builder.Property(a => a.ZipCode)
            .HasMaxLength(50);

        builder.Property(a => a.Country)
            .IsRequired()
            .HasMaxLength(255);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(a => a.CreatedByUser)
            .WithMany()
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.UpdatedByUser)
            .WithMany()
            .HasForeignKey(a => a.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.DeletedByUser)
            .WithMany()
            .HasForeignKey(a => a.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}