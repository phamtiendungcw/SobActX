namespace SAX.Application.Features.Users.DTOs.Role;

public class CreateRoleDto
{
    public string RoleName { get; set; } = string.Empty;
    public string? Description { get; set; }
}