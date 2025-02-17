using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Promotions;

public class PromotionCategory : BaseEntity
{
    public int PromotionId { get; set; } // Foreign key to Promotion
    public Promotion? Promotion { get; set; } // Navigation property
    public int ProductCategoryId { get; set; } // Foreign key to ProductCategory
    public ProductCategory? ProductCategory { get; set; } // Navigation property
}