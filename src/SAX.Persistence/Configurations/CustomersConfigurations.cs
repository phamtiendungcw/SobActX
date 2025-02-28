using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Customers;

namespace SAX.Persistence.Configurations;

public class CustomersConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.RegistrationDate).IsRequired();
            builder.HasOne(c => c.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ProductReviews)
                .WithOne(pr => pr.Customer)
                .HasForeignKey(pr => pr.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.StreetAddress).IsRequired().HasMaxLength(255);
            builder.Property(a => a.City).IsRequired().HasMaxLength(100);
            builder.Property(a => a.State).HasMaxLength(100);
            builder.Property(a => a.ZipCode).HasMaxLength(20);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(100);
        }
    }
}