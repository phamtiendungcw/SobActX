using SAX.Domain.Entities.Promotions;

namespace SAX.Domain.Entities.Products;

public class ProductCategory
{
    public int ProductCategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>(); // Navigation property
    public ICollection<PromotionCategory> PromotionCategories { get; set; } = new List<PromotionCategory>(); // Navigation property
}