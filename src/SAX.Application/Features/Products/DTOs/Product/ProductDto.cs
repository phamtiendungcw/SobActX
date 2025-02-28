namespace SAX.Application.Features.Products.DTOs.Product;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SKU { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public string? ImageUrl { get; set; }
    public ProductCategoryDto? Category { get; set; }
    public ProductBrandDto? Brand { get; set; }
}