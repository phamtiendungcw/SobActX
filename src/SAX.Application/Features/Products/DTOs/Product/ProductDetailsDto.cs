using SAX.Application.Features.Inventory.DTOs.ProductInventory;
using SAX.Application.Features.Products.DTOs.ProductReview;

namespace SAX.Application.Features.Products.DTOs.Product;

public class ProductDetailsDto : ProductDto
{
    public List<ProductInventoryDto> ProductInventories { get; set; } = new();
    public List<ProductAttributeValueDto> ProductAttributeValues { get; set; } = new();
    public List<ProductReviewDto> ProductReviews { get; set; } = new();
}