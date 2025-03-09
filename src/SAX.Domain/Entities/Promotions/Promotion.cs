namespace SAX.Domain.Entities.Promotions;

public class Promotion : BaseEntity
{
    public string PromotionName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PromotionType PromotionType { get; set; } // e.g., "Percentage", "FixedAmount"
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? CouponCode { get; set; } // Optional coupon code
    public decimal? MinimumOrderValue { get; set; } // Minimum order value to apply promotion
    public ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();
    public ICollection<PromotionCategory> PromotionCategories { get; set; } = new List<PromotionCategory>();
}