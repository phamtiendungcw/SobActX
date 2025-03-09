namespace SAX.Domain.Entities.Content;

public class BlogPostTag : BaseEntity
{
    public Guid BlogPostId { get; set; }
    public BlogPost? BlogPost { get; set; }
    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}