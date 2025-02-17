using SAX.Application.Features.Users.DTOs.RolePermission;

namespace SAX.Application.Features.Users.DTOs.Permission;

public class PermissionDetailsDto : PermissionDto
{
    public List<RolePermissionDto> RolePermissions { get; set; } = new();
}