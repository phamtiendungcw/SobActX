using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCarts");
        builder.HasKey(sc => sc.Id);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(sc => sc.CreatedByUser)
            .WithMany()
            .HasForeignKey(sc => sc.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sc => sc.UpdatedByUser)
            .WithMany()
            .HasForeignKey(sc => sc.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sc => sc.DeletedByUser)
            .WithMany()
            .HasForeignKey(sc => sc.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}