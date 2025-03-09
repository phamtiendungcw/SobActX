namespace SAX.Domain.Entities.Content;

public class Tag : BaseEntity
{
    public string TagName { get; set; } = string.Empty;
    public ICollection<BlogPostTag> BlogPostTags { get; set; } = new List<BlogPostTag>();
}