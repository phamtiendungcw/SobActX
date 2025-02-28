using SAX.Domain.Entities.Inventory;
using SAX.Domain.Entities.Orders;
using SAX.Domain.Entities.Promotions;

namespace SAX.Domain.Entities.Products;

public class Product : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SKU { get; set; } = string.Empty; // Stock Keeping Unit
    public decimal UnitPrice { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; } // Foreign key to ProductCategory
    public ProductCategory? Category { get; set; } // Navigation property
    public Guid? BrandId { get; set; } // Foreign key to ProductBrand, nullable
    public ProductBrand? Brand { get; set; } // Navigation property
    public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>(); // Navigation property
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Navigation property
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>(); // Navigation property
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>(); // Navigation property
    public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>(); // Navigation property
    public ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>(); // Navigation property
}