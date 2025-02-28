namespace SAX.Application.Features.Products.DTOs.ProductReview;

public class UpdateProductReviewDto
{
    public Guid ProductReviewId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; } // Cho phép admin cập nhật trạng thái duyệt
}