using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
    /// <summary>
    ///     Liệt kê các role permissions của một role cụ thể.
    /// </summary>
    Task<IReadOnlyList<RolePermission>> GetRolePermissionsForRoleAsync(Guid roleId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các role permissions của một permission cụ thể.
    /// </summary>
    Task<IReadOnlyList<RolePermission>> GetRolePermissionsForPermissionAsync(Guid permissionId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy role permission theo role ID và permission ID (cho mục đích kiểm tra xem role đã có permission này chưa).
    /// </summary>
    Task<RolePermission?> GetRolePermissionByRoleAndPermissionAsync(Guid roleId, Guid permissionId, CancellationToken cancellationToken = default);
}