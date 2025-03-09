using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities.Content;

public class BlogPost : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public DateTime? PublishedAt { get; set; }
    public Guid AuthorId { get; set; }
    public User? Author { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<BlogPostTag> BlogPostsTags { get; set; } = new List<BlogPostTag>();
}