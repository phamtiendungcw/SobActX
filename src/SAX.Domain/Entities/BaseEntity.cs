using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public User? CreatedByUser { get; set; }
    public Guid? UpdatedByUserId { get; set; }
    public User? UpdatedByUser { get; set; }
    public Guid? DeletedByUserId { get; set; }
    public User? DeletedByUser { get; set; }
}