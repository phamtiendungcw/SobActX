namespace SAX.Domain.Entities.Users;

public class Role : BaseEntity
{
    public string RoleName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}