using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Role?> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName, cancellationToken);
    }
}