namespace SAX.Application.Features.Content.DTOs.Page;

public class CreatePageDto
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public string? ContentSummary { get; set; }
    public DateTime? PublishedAt { get; set; }
    public Guid AuthorId { get; set; }
}