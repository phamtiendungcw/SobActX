using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Orders;

public class ShoppingCart : BaseEntity
{
    public Guid CustomerId { get; set; } // Foreign key to Customer
    public Customer? Customer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}