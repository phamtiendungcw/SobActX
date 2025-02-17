namespace SAX.Domain.Entities.Promotions;

public class PromotionProduct
{
    public int PromotionProductId { get; set; }
    public int PromotionId { get; set; } // Foreign key to Promotion
    public Promotion? Promotion { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Products.Product? Product { get; set; } // Navigation property
}