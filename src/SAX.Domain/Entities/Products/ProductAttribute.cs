namespace SAX.Domain.Entities.Products;

public class ProductAttribute : BaseEntity
{
    public string AttributeName { get; set; } = string.Empty;
    public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>(); // Navigation property
}