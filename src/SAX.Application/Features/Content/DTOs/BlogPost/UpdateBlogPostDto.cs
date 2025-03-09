namespace SAX.Application.Features.Content.DTOs.BlogPost;

public class UpdateBlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public string? ContentSummary { get; set; }
    public DateTime? PublishedAt { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
}