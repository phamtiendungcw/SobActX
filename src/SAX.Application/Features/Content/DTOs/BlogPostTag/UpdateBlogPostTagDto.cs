namespace SAX.Application.Features.Content.DTOs.BlogPostTag;

public class UpdateBlogPostTagDto
{
    public Guid Id { get; set; }
    public Guid BlogPostId { get; set; }
    public Guid TagId { get; set; }
}