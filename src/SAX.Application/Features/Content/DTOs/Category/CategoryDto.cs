namespace SAX.Application.Features.Content.DTOs.Category;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
}