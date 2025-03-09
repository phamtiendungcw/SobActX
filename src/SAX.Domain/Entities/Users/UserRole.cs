namespace SAX.Domain.Entities.Users;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; } // Foreign key to User
    public User? User { get; set; }
    public Guid RoleId { get; set; } // Foreign key to Role
    public Role? Role { get; set; }
}