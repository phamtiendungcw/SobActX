namespace SAX.Domain.Entities.Orders;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Products.Product? Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineItemTotal { get; set; }
}