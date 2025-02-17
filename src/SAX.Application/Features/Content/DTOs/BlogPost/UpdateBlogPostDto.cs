namespace SAX.Application.Features.Content.DTOs.BlogPost;

public class UpdateBlogPostDto
{
    public Guid BlogPostId { get; set; }
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public string? ContentBody { get; set; }
    public DateTime? PublishDate { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }
    public List<Guid>? TagIds { get; set; } // Allow updating tags
}