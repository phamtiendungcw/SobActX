namespace SAX.Application.Features.Products.DTOs.Product;

public class ProductDetailsDto : ProductDto
{
    public string CategoryName { get; set; } = string.Empty;
    public string? BrandName { get; set; }
}