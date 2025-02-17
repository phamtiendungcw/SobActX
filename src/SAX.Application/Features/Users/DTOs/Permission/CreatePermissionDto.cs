namespace SAX.Application.Features.Users.DTOs.Permission;

public class CreatePermissionDto
{
    public string PermissionName { get; set; } = string.Empty;
    public string? Description { get; set; }
}