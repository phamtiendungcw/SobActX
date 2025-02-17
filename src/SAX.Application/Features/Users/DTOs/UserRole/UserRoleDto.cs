using SAX.Application.Features.Users.DTOs.Role;

namespace SAX.Application.Features.Users.DTOs.UserRole;

public class UserRoleDto
{
    public Guid UserRoleId { get; set; }
    public RoleDto? Role { get; set; }
}