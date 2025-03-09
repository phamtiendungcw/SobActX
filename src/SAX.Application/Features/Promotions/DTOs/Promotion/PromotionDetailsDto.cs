namespace SAX.Application.Features.Promotions.DTOs.Promotion;

public class PromotionDetailsDto : PromotionDto
{
    public List<PromotionProductDto> PromotionProducts { get; set; } = new();
    public List<PromotionCategoryDto> PromotionCategories { get; set; } = new();
}