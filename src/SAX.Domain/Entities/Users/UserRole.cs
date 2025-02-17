namespace SAX.Domain.Entities.Users;

public class UserRole : BaseEntity
{
    public int UserId { get; set; } // Foreign key to User
    public User? User { get; set; } // Navigation property
    public int RoleId { get; set; } // Foreign key to Role
    public Role? Role { get; set; } // Navigation property
}