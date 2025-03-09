using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

/// <summary>
///     Interface cho repository của entity Role.
/// </summary>
public interface IRoleRepository : IGenericRepository<Role>
{
    /// <summary>
    ///     Lấy một Role theo RoleName một cách bất đồng bộ.
    /// </summary>
    /// <param name="roleName">RoleName của Role.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Role nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Role?> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = default);
}