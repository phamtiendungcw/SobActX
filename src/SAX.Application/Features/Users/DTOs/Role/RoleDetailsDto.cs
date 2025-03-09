namespace SAX.Application.Features.Users.DTOs.Role;

public class RoleDetailsDto : RoleDto
{
    public List<UserRoleDto> UserRoles { get; set; } = new();
    public List<RolePermissionDto> RolePermissions { get; set; } = new();
}