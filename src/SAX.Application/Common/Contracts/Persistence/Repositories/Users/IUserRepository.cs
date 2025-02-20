using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

public interface IUserRepository : IGenericRepository<User>
{
    /// <summary>
    ///     Lấy người dùng theo username (cho đăng nhập, kiểm tra tồn tại).
    /// </summary>
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy người dùng theo email (cho quên mật khẩu, kiểm tra tồn tại).
    /// </summary>
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các người dùng thuộc về một role cụ thể.
    /// </summary>
    Task<IReadOnlyList<User>> GetUsersByRoleAsync(Guid roleId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm người dùng theo tên hoặc username.
    /// </summary>
    Task<IReadOnlyList<User>> SearchUsersAsync(string searchTerm, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các người dùng đăng ký mới nhất (cho dashboard quản lý người dùng).
    /// </summary>
    Task<IReadOnlyList<User>> ListLatestRegisteredUsersAsync(int count, CancellationToken cancellationToken = default);
}