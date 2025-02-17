namespace SAX.Application.Features.Content.DTOs.Page;

public class UpdatePageDto
{
    public Guid PageId { get; set; }
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public string? ContentBody { get; set; }
    public DateTime? PublishDate { get; set; }
    public Guid? AuthorId { get; set; } // Allow changing author
}