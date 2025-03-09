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
    public ProductCategory? Category { get; set; }
    public Guid? BrandId { get; set; } // Foreign key to ProductBrand, nullable
    public ProductBrand? Brand { get; set; }
    public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
    public ICollection<PromotionProduct> PromotionsProducts { get; set; } = new List<PromotionProduct>();
}