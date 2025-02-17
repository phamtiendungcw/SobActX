namespace SAX.Application.Features.Content.DTOs.BlogPost
{
    public class BlogPostDto
    {
        public Guid BlogPostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ContentBody { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
