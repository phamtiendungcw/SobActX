namespace SAX.Application.Features.Content.DTOs.BlogPost;

public class CreateBlogPostDto
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public DateTime PublishDate { get; set; }
    public Guid AuthorId { get; set; } // Foreign Key - User
    public Guid CategoryId { get; set; } // Foreign Key - Category
    public List<Guid> TagIds { get; set; } = new(); // List of Tag IDs
}