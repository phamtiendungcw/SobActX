namespace SAX.Application.Features.Content.DTOs.BlogPost;

public class BlogPostDetailsDto : BlogPostDto
{
    public string AuthorName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
}