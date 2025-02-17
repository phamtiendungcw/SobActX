namespace SAX.Application.Features.Users.DTOs.Permission;

public class PermissionDto
{
    public Guid PermissionId { get; set; }
    public string PermissionName { get; set; } = string.Empty;
    public string? Description { get; set; }
}