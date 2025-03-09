using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

/// <summary>
///     Interface cho repository của entity Permission.
/// </summary>
public interface IPermissionRepository : IGenericRepository<Permission>
{
    /// <summary>
    ///     Lấy một Permission theo PermissionName một cách bất đồng bộ.
    /// </summary>
    /// <param name="permissionName">PermissionName của Permission.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Permission nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Permission?> GetPermissionByNameAsync(string permissionName, CancellationToken cancellationToken = default);
}