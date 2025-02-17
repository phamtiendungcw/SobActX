using SAX.Application.Features.Content.DTOs.Category;
using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Content.DTOs.BlogPost;

public class BlogPostDetailsDto : BlogPostDto
{
    public UserDto? Author { get; set; }
    public CategoryDto? Category { get; set; }
}