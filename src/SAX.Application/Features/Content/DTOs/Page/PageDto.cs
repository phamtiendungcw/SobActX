using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Content.DTOs.Page;

public class PageDto
{
    public Guid PageId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ContentBody { get; set; }
    public DateTime PublishDate { get; set; }
    public UserDto? Author { get; set; }
}