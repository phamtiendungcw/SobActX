using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

/// <summary>
///     Repository cho entity Role.
/// </summary>
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    /// <summary>
    ///     Khởi tạo một instance của RoleRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public RoleRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Role?> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName && !r.IsDeleted && r.IsActive, cancellationToken);
    }
}