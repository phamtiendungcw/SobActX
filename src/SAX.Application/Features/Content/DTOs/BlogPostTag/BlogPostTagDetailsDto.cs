namespace SAX.Application.Features.Content.DTOs.BlogPostTag;

public class BlogPostTagDetailsDto : BlogPostTagDto
{
    public string BlogPostTitle { get; set; } = string.Empty;
    public string TagName { get; set; } = string.Empty;
}