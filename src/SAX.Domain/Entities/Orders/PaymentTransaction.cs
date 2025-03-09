namespace SAX.Domain.Entities.Orders;

public class PaymentTransaction : BaseEntity
{
    public Guid OrderId { get; set; } // Foreign key to Order
    public Order? Order { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; } // Enum {"Pending", "Approved", "Rejected"}
    public string? PaymentGatewayReference { get; set; } // Transaction ID from payment gateway
}