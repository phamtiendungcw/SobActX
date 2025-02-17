namespace SAX.Domain.Entities.Content;

public class Tag
{
    public int TagId { get; set; }
    public string TagName { get; set; } = string.Empty;
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); // Navigation property
}