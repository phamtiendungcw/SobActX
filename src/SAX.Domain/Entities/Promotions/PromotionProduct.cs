using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Promotions;

public class PromotionProduct : BaseEntity
{
    public Guid PromotionId { get; set; } // Foreign key to Promotion
    public Promotion? Promotion { get; set; }
    public Guid ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; }
}