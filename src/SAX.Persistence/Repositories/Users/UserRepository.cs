using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Domain.Entities.Users;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(Guid roleId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UsersRoles
            .Where(ur => ur.RoleId == roleId)
            .Select(ur => ur.User) // Select User từ UserRole
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<User>> SearchUsersAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .Where(u => u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm) || u.Username.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<User>> ListLatestRegisteredUsersAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .OrderByDescending(u => u.RegistrationDate)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}