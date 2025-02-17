using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.DTOs.Tag;

public class TagDetailsDto : TagDto
{
    public List<BlogPostDto> BlogPosts { get; set; } = new();
}