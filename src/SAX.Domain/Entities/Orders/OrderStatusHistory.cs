namespace SAX.Domain.Entities.Orders;

public class OrderStatusHistory : BaseEntity
{
    public Guid OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; } // Navigation property
    public string Status { get; set; } = string.Empty; // Order status value
    public DateTime StatusDate { get; set; }
    public string? Notes { get; set; } // Optional notes for status change
}