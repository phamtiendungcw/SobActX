namespace SAX.Domain.Entities.Products;

public class ProductAttributeValue : BaseEntity
{
    public Guid ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; }
    public Guid ProductAttributeId { get; set; } // Foreign key to ProductAttribute
    public ProductAttribute? ProductAttribute { get; set; }
    public string Value { get; set; } = string.Empty;
}