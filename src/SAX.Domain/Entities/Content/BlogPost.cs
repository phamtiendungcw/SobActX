using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities.Content;

public class BlogPost : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public DateTime PublishDate { get; set; }
    public Guid AuthorId { get; set; } // Foreign key to User
    public User? Author { get; set; } // Navigation property
    public Guid CategoryId { get; set; } // Foreign key to Category
    public Category? Category { get; set; } // Navigation property
    public ICollection<Tag> Tags { get; set; } = new List<Tag>(); // Collection of tags
}