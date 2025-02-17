using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities.Content;

public class Page : BaseEntity
{
    public string Title { get; set; } = string.Empty; // Non-nullable for required fields
    public string Slug { get; set; } = string.Empty; // Non-nullable
    public string? ContentBody { get; set; } // Nullable as content might be optional initially
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; } // Foreign key to User
    public User? Author { get; set; } // Navigation property
}