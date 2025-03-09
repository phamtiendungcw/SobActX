using SAX.Domain;

namespace SAX.Application.Features.Promotions.DTOs.Promotion;

public class UpdatePromotionDto
{
    public Guid Id { get; set; }
    public string PromotionName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PromotionType PromotionType { get; set; } = PromotionType.Percentage;
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? CouponCode { get; set; }
    public decimal? MinimumOrderValue { get; set; }
}