namespace SAX.Application.Features.Products.DTOs;

public class ProductBrandDto
{
    public Guid Id { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string? Description { get; set; }
}