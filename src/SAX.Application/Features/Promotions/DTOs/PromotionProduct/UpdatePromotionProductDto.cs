namespace SAX.Application.Features.Promotions.DTOs.PromotionProduct;

public class UpdatePromotionProductDto
{
    public Guid PromotionProductId { get; set; }
    public Guid? PromotionId { get; set; }
    public Guid? ProductId { get; set; }
}