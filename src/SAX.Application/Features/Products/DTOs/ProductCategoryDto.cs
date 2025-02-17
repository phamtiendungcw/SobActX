namespace SAX.Application.Features.Products.DTOs;

public class ProductCategoryDto
{
    public Guid ProductCategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
}