namespace SAX.Application.Features.Users.DTOs.RolePermission;

public class UpdateRolePermissionDto
{
    public Guid RolePermissionId { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? PermissionId { get; set; }
}