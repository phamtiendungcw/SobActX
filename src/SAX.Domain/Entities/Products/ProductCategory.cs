using SAX.Domain.Entities.Promotions;

namespace SAX.Domain.Entities.Products;

public class ProductCategory : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<PromotionCategory> PromotionCategories { get; set; } = new List<PromotionCategory>();
}