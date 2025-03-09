namespace SAX.Domain.Entities.Users;

public class RolePermission : BaseEntity
{
    public Guid RoleId { get; set; } // Foreign key to Role
    public Role? Role { get; set; }
    public Guid PermissionId { get; set; } // Foreign key to Permission
    public Permission? Permission { get; set; }
}