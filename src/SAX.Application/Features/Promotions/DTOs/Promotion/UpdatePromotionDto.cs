namespace SAX.Application.Features.Promotions.DTOs.Promotion;

public class UpdatePromotionDto
{
    public Guid PromotionId { get; set; }
    public string? PromotionName { get; set; }
    public string? Description { get; set; }
    public string? PromotionType { get; set; }
    public decimal? DiscountValue { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? CouponCode { get; set; }
    public decimal? MinimumOrderValue { get; set; }
}