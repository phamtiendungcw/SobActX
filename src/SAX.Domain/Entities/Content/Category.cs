namespace SAX.Domain.Entities.Content;

public class Category : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); // Navigation property
}