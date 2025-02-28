using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Products;

public class ProductReview : BaseEntity
{
    public Guid ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
    public Guid CustomerId { get; set; } // Foreign key to Customer
    public Customer? Customer { get; set; } // Navigation property
    public int Rating { get; set; } // e.g., 1 to 5 stars
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool IsApproved { get; set; } // Admin approval for review visibility
}