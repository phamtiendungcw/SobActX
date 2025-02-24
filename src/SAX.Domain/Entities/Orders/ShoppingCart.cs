using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Orders;

public class ShoppingCart : BaseEntity
{
    public int CustomerId { get; set; } // Foreign key to Customer
    public Customer? Customer { get; set; } // Navigation property
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>(); // Navigation property
}