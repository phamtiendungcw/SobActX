namespace SAX.Application.Features.Promotions.DTOs;

public class PromotionCategoryDto
{
    public Guid Id { get; set; }
    public Guid PromotionId { get; set; }
    public Guid ProductCategoryId { get; set; }
}