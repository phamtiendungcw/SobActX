using SAX.Application.Features.Products.DTOs.Product;
using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.DTOs.PromotionProduct;

public class PromotionProductDto
{
    public Guid PromotionProductId { get; set; }
    public PromotionDto? Promotion { get; set; }
    public ProductDto? Product { get; set; }
}