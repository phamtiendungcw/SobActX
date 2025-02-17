using SAX.Application.Features.Customers.DTOs.Customer;
using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.DTOs;

public class ProductReviewDto
{
    public Guid ProductReviewId { get; set; }
    public ProductDto? Product { get; set; }
    public CustomerDto? Customer { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool IsApproved { get; set; }
}