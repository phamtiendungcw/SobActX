namespace SAX.Application.Features.Content.DTOs.Category;

public class UpdateCategoryDto
{
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
}