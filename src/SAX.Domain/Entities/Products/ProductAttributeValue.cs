namespace SAX.Domain.Entities.Products;

public class ProductAttributeValue : BaseEntity
{
    public int ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
    public int ProductAttributeId { get; set; } // Foreign key to ProductAttribute
    public ProductAttribute? ProductAttribute { get; set; } // Navigation property
    public string Value { get; set; } = string.Empty;
}