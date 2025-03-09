using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

/// <summary>
///     Repository cho entity Permission.
/// </summary>
public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    /// <summary>
    ///     Khởi tạo một instance của PermissionRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public PermissionRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Permission?> GetPermissionByNameAsync(string permissionName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions.FirstOrDefaultAsync(p => p.PermissionName == permissionName && !p.IsDeleted && p.IsActive, cancellationToken);
    }
}