namespace SAX.Domain.Entities.Orders;

public class ShoppingCart
{
    public int ShoppingCartId { get; set; }
    public int CustomerId { get; set; } // Foreign key to Customer
    public Customers.Customer? Customer { get; set; } // Navigation property
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>(); // Navigation property
}