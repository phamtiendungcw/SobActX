namespace SAX.Domain.Entities.Products;

public class ProductBrand : BaseEntity
{
    public string BrandName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>(); // Navigation property
}