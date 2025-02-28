namespace SAX.Domain.Entities.Orders;

public class PaymentTransaction : BaseEntity
{
    public Guid OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; } // Navigation property
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty; // e.g., "Pending", "Approved", "Rejected"
    public string? PaymentGatewayReference { get; set; } // Transaction ID from payment gateway
}