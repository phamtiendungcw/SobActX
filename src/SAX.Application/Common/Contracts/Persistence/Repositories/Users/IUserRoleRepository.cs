using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    /// <summary>
    ///     Liệt kê các user roles của một người dùng cụ thể.
    /// </summary>
    Task<IReadOnlyList<UserRole>> GetUserRolesForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các user roles của một role cụ thể.
    /// </summary>
    Task<IReadOnlyList<UserRole>> GetUserRolesForRoleAsync(Guid roleId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy user role theo user ID và role ID (cho mục đích kiểm tra xem user đã có role này chưa).
    /// </summary>
    Task<UserRole?> GetUserRoleByUserAndRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default);
}