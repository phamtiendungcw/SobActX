namespace SAX.Domain.Entities.Content;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); // Navigation property
}