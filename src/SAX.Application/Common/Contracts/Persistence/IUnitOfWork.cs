using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

/// <summary>
///     Quản lý transaction và DbContext lifecycle.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    ///     Lấy repository cho một entity cụ thể.
    /// </summary>
    /// <typeparam name="TEntity">Loại entity.</typeparam>
    /// <returns>Repository cho entity.</returns>
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    /// <summary>
    ///     Lưu tất cả các thay đổi vào database trong transaction hiện tại một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Task đại diện cho hoạt động lưu.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Bắt đầu một transaction mới.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    ///     Commit transaction hiện tại.
    /// </summary>
    void CommitTransaction();

    /// <summary>
    ///     Rollback transaction hiện tại.
    /// </summary>
    void RollbackTransaction();
}