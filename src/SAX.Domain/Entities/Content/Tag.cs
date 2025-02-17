namespace SAX.Domain.Entities.Content;

public class Tag : BaseEntity
{
    public string TagName { get; set; } = string.Empty;
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); // Navigation property
}