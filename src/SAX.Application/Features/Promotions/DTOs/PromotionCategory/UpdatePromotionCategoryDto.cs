namespace SAX.Application.Features.Promotions.DTOs.PromotionCategory;

public class UpdatePromotionCategoryDto
{
    public Guid PromotionCategoryId { get; set; }
    public Guid? PromotionId { get; set; }
    public Guid? ProductCategoryId { get; set; }
}