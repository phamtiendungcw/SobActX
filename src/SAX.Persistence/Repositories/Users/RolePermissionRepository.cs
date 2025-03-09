using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
{
    public RolePermissionRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<RolePermission>> GetRolePermissionsForRoleAsync(Guid roleId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.RolesPermissions
            .Where(rp => rp.RoleId == roleId)
            .Include(rp => rp.Permission) // Eager load Role và Permission
            .Include(rp => rp.Role)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RolePermission>> GetRolePermissionsForPermissionAsync(Guid permissionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.RolesPermissions
            .Where(rp => rp.PermissionId == permissionId)
            .Include(rp => rp.Permission) // Eager load Role và Permission
            .Include(rp => rp.Role)
            .ToListAsync(cancellationToken);
    }

    public async Task<RolePermission?> GetRolePermissionByRoleAndPermissionAsync(Guid roleId, Guid permissionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.RolesPermissions
            .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId, cancellationToken);
    }
}