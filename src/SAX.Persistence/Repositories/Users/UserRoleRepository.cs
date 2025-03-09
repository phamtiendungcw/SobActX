using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<UserRole>> GetUserRolesForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UsersRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role) // Eager load Role và User
            .Include(ur => ur.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<UserRole>> GetUserRolesForRoleAsync(Guid roleId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UsersRoles
            .Where(ur => ur.RoleId == roleId)
            .Include(ur => ur.Role) // Eager load Role và User
            .Include(ur => ur.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<UserRole?> GetUserRoleByUserAndRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UsersRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId, cancellationToken);
    }
}