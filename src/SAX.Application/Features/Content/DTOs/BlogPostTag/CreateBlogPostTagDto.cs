namespace SAX.Application.Features.Content.DTOs.BlogPostTag;

public class CreateBlogPostTagDto
{
    public Guid BlogPostId { get; set; }
    public Guid TagId { get; set; }
}