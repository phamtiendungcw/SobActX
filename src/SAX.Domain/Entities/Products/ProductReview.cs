namespace SAX.Domain.Entities.Products;

public class ProductReview
{
    public int ProductReviewId { get; set; }
    public int ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
    public int CustomerId { get; set; } // Foreign key to Customer
    public Customers.Customer? Customer { get; set; } // Navigation property
    public int Rating { get; set; } // e.g., 1 to 5 stars
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool IsApproved { get; set; } // Admin approval for review visibility
}