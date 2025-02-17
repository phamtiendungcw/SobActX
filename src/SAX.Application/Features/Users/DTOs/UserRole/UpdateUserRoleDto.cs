namespace SAX.Application.Features.Users.DTOs.UserRole;

public class UpdateUserRoleDto
{
    public Guid UserRoleId { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? UserId { get; set; }
}