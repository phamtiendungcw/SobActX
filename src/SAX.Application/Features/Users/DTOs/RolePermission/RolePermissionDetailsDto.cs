using SAX.Application.Features.Users.DTOs.Role;

namespace SAX.Application.Features.Users.DTOs.RolePermission;

public class RolePermissionDetailsDto : RolePermissionDto
{
    public RoleDto? Role { get; set; }
}