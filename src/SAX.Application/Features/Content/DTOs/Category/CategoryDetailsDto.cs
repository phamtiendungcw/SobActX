using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.DTOs.Category;

public class CategoryDetailsDto : CategoryDto
{
    public List<BlogPostDto> BlogPosts { get; set; } = new();
}