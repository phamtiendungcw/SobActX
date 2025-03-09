using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SAX.Domain.Entities.Orders;

namespace SAX.Persistence.Configurations.OrdersConfiguration;

public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItems");
        builder.HasKey(sci => sci.Id);

        builder.HasOne(sci => sci.ShoppingCart)
            .WithMany(sc => sc.ShoppingCartItems)
            .HasForeignKey(sci => sci.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa ShoppingCartItem khi ShoppingCart bị xóa

        builder.HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Cấu hình cho các thuộc tính của BaseEntity
        builder.HasOne(sci => sci.CreatedByUser)
            .WithMany()
            .HasForeignKey(sci => sci.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sci => sci.UpdatedByUser)
            .WithMany()
            .HasForeignKey(sci => sci.UpdatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sci => sci.DeletedByUser)
            .WithMany()
            .HasForeignKey(sci => sci.DeletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}