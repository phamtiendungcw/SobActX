using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

/// <summary>
///     Repository cho entity User.
/// </summary>
public class UserRepository : GenericRepository<User>, IUserRepository
{
    /// <summary>
    ///     Khởi tạo một instance của UserRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public UserRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted && u.IsActive, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted && u.IsActive, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .Where(u => u.UserRoles.Any(ur => ur.Role!.RoleName == roleName) && !u.IsDeleted && u.IsActive)
            .ToListAsync(cancellationToken);
    }
}