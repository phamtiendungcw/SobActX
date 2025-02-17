namespace SAX.Application.Features.Users.DTOs.Permission;

public class UpdatePermissionDto
{
    public Guid PermissionId { get; set; }
    public string? PermissionName { get; set; }
    public string? Description { get; set; }
}