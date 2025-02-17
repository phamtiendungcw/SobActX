using SAX.Application.Features.Users.DTOs.Permission;

namespace SAX.Application.Features.Users.DTOs.RolePermission;

public class RolePermissionDto
{
    public Guid RolePermissionId { get; set; }
    public PermissionDto? Permission { get; set; }
}