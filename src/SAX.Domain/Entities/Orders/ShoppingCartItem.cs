namespace SAX.Domain.Entities.Orders;

public class ShoppingCartItem : BaseEntity
{
    public int ShoppingCartId { get; set; } // Foreign key to ShoppingCart
    public ShoppingCart? ShoppingCart { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Products.Product? Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }
}