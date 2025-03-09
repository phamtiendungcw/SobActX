using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Customers;
using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.CustomersConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20)
            .HasAnnotation("RegularExpression", @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");

        builder.HasOne(c => c.Address)
            .WithMany(a => a.Customers)
            .HasForeignKey(c => c.AddressId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Address thì set AddressId của Customer thành null

        builder.HasOne(c => c.ShoppingCart)
            .WithOne(sc => sc.Customer)
            .HasForeignKey<ShoppingCart>(sc => sc.CustomerId).OnDelete(DeleteBehavior.Cascade); // Xóa ShoppingCart khi Customer bị xóa

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