using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Orders;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; } // Foreign key to Customer
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; } // Enum {"Pending", "Processing", "Shipped", "Completed", "Cancelled"}
    public Guid? ShippingAddressId { get; set; } // Foreign key to Address, nullable
    public Address? ShippingAddress { get; set; }
    public Guid? BillingAddressId { get; set; } // Foreign key to Address, nullable
    public Address? BillingAddress { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // e.g., "Credit Card", "PayPal"
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; } // Discount might be optional
    public decimal? ShippingCost { get; set; } // Shipping cost might be optional
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();
    public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();
}