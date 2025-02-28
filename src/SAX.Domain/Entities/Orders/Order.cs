using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Orders;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; } // Foreign key to Customer
    public Customer? Customer { get; set; } // Navigation property
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; } = string.Empty; // e.g., "Pending", "Processing", "Shipped", "Completed"
    public Guid? ShippingAddressId { get; set; } // Foreign key to Address, nullable
    public Address? ShippingAddress { get; set; } // Navigation property
    public Guid? BillingAddressId { get; set; } // Foreign key to Address, nullable
    public Address? BillingAddress { get; set; } // Navigation property
    public string PaymentMethod { get; set; } = string.Empty; // e.g., "Credit Card", "PayPal"
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; } // Discount might be optional
    public decimal? ShippingCost { get; set; } // Shipping cost might be optional
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Navigation property
    public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>(); // Navigation property
    public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>(); // Navigation property
}