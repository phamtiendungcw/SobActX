namespace SAX.Application.Features.Products.DTOs.Product;

public class CreateProductDto
{
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SKU { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? BrandId { get; set; }
}