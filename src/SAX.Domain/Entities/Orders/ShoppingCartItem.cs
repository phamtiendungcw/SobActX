using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Orders;

public class ShoppingCartItem : BaseEntity
{
    public Guid ShoppingCartId { get; set; } // Foreign key to ShoppingCart
    public ShoppingCart? ShoppingCart { get; set; } // Navigation property
    public Guid ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }
}