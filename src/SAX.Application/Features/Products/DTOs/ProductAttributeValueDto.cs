namespace SAX.Application.Features.Products.DTOs;

public class ProductAttributeValueDto
{
    public Guid ProductAttributeValueId { get; set; }
    public string Value { get; set; } = string.Empty;
    public ProductAttributeDto? Attribute { get; set; }
}