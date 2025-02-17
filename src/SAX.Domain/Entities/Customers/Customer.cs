using SAX.Domain.Entities.Orders;
using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Customers;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int? AddressId { get; set; } // Foreign key to Address, nullable as address might be optional
    public Address? Address { get; set; } // Navigation property
    public ICollection<Order> Orders { get; set; } = new List<Order>(); // Navigation property
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>(); // Navigation property
    public ShoppingCart? ShoppingCart { get; set; } // Navigation property
}