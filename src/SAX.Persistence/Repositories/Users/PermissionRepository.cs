using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Permission?> GetPermissionByNameAsync(string permissionName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions.FirstOrDefaultAsync(p => p.PermissionName == permissionName, cancellationToken);
    }
}