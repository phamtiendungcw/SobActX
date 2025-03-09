namespace SAX.Domain.Entities.Orders;

public class OrderStatusHistory : BaseEntity
{
    public Guid OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; }
    public OrderStatus Status { get; set; } // Order status value
    public DateTime StatusDate { get; set; }
    public string? Notes { get; set; } // Optional notes for status change
}