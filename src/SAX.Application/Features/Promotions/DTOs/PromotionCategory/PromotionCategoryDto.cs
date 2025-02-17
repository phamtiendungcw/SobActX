using SAX.Application.Features.Products.DTOs;
using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.DTOs.PromotionCategory;

public class PromotionCategoryDto
{
    public Guid PromotionCategoryId { get; set; }
    public PromotionDto? Promotion { get; set; }
    public ProductCategoryDto? ProductCategory { get; set; }
}