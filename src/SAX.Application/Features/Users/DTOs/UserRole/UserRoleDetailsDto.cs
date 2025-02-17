using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.DTOs.UserRole;

public class UserRoleDetailsDto : UserRoleDto
{
    public UserDto? User { get; set; }
}