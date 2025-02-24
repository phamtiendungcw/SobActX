using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineItemTotal { get; set; }
}