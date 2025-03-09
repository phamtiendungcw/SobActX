using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

/// <summary>
///     Interface cho repository của entity User.
/// </summary>
public interface IUserRepository : IGenericRepository<User>
{
    /// <summary>
    ///     Lấy một User theo username một cách bất đồng bộ.
    /// </summary>
    /// <param name="username">Username của User.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>User nếu tìm thấy, ngược lại trả về null.</returns>
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy một User theo email một cách bất đồng bộ.
    /// </summary>
    /// <param name="email">Email của User.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>User nếu tìm thấy, ngược lại trả về null.</returns>
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các User trong một Role nhất định một cách bất đồng bộ.
    /// </summary>
    /// <param name="roleName">Tên của Role.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách User trong Role.</returns>
    Task<IReadOnlyList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default);
}