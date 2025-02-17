using SAX.Application.Features.Users.DTOs.UserRole;

namespace SAX.Application.Features.Users.DTOs.User;

public class UserDetailsDto : UserDto
{
    public List<UserRoleDto> UserRoles { get; set; } = new();
}