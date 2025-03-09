namespace SAX.Application.Features.Products.DTOs.ProductReview;

public class CreateProductReviewDto
{
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool IsApproved { get; set; }
}