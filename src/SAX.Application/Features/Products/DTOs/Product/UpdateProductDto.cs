namespace SAX.Application.Features.Products.DTOs.Product;

public class UpdateProductDto
{
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? ImageUrl { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? BrandId { get; set; }
}