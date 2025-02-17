namespace SAX.Domain.Entities.Users;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>(); // Navigation property
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>(); // Navigation property
}