using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    /// <summary>
    ///     Lấy permission theo tên permission (cho mục đích kiểm tra tính duy nhất, phân quyền).
    /// </summary>
    Task<Permission?> GetPermissionByNameAsync(string permissionName, CancellationToken cancellationToken = default);
}