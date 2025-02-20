using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Users;

public interface IRoleRepository : IGenericRepository<Role>
{
    /// <summary>
    ///     Lấy role theo tên role (cho mục đích kiểm tra tính duy nhất, phân quyền).
    /// </summary>
    Task<Role?> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = default);
}