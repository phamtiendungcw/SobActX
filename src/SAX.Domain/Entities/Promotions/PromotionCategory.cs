using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Promotions;

public class PromotionCategory : BaseEntity
{
    public Guid PromotionId { get; set; } // Foreign key to Promotion
    public Promotion? Promotion { get; set; } // Navigation property
    public Guid ProductCategoryId { get; set; } // Foreign key to ProductCategory
    public ProductCategory? ProductCategory { get; set; } // Navigation property
}