namespace SAX.Application.Features.Promotions.DTOs.Promotion;

public class CreatePromotionDto
{
    public string PromotionName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string PromotionType { get; set; } = string.Empty;
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? CouponCode { get; set; }
    public decimal? MinimumOrderValue { get; set; }
}