namespace SAX.Domain.Entities.Products;

public class ProductAttribute
{
    public int ProductAttributeId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>(); // Navigation property
}