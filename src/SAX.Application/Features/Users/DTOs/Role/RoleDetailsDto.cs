using SAX.Application.Features.Users.DTOs.RolePermission;
using SAX.Application.Features.Users.DTOs.UserRole;

namespace SAX.Application.Features.Users.DTOs.Role;

public class RoleDetailsDto : RoleDto
{
    public List<UserRoleDto> UserRoles { get; set; } = new();
    public List<RolePermissionDto> RolePermissions { get; set; } = new();
}