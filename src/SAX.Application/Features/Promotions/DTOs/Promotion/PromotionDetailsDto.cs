using SAX.Application.Features.Promotions.DTOs.PromotionCategory;
using SAX.Application.Features.Promotions.DTOs.PromotionProduct;

namespace SAX.Application.Features.Promotions.DTOs.Promotion;

public class PromotionDetailsDto : PromotionDto
{
    public List<PromotionProductDto> PromotionProducts { get; set; } = new();
    public List<PromotionCategoryDto> PromotionCategories { get; set; } = new();
}