namespace SAX.Application.Features.Users.DTOs.User;

public class UserDetailsDto : UserDto
{
    public List<string> Roles { get; set; } = new();
}