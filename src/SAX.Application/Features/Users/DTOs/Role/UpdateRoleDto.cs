namespace SAX.Application.Features.Users.DTOs.Role;

public class UpdateRoleDto
{
    public Guid RoleId { get; set; }
    public string? RoleName { get; set; }
    public string? Description { get; set; }
}