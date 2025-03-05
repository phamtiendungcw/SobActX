using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    // --- Read Operations ---

    /// <summary>
    ///     Lấy một entity theo ID một cách bất đồng bộ.
    /// </summary>
    /// <param name="id">ID của entity.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Entity nếu tìm thấy, ngược lại trả về null.</returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê tất cả các entity một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách chỉ đọc của tất cả các entity.</returns>
    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các entity dựa trên một specification một cách bất đồng bộ.
    /// </summary>
    /// <param name="specification">Specification để áp dụng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách chỉ đọc của các entity phù hợp với specification.</returns>
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Đếm số lượng entity dựa trên một specification một cách bất đồng bộ.
    /// </summary>
    /// <param name="specification">Specification để áp dụng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Số lượng entity phù hợp với specification.</returns>
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Trả về entity đầu tiên phù hợp với specification, hoặc null nếu không có entity nào phù hợp.
    /// </summary>
    /// <param name="specification">Specification để áp dụng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Entity đầu tiên phù hợp với specification, hoặc null.</returns>
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Trả về entity duy nhất phù hợp với specification, hoặc null nếu không có entity nào hoặc có nhiều hơn một entity
    ///     phù hợp.
    /// </summary>
    /// <param name="specification">Specification để áp dụng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Entity duy nhất phù hợp với specification, hoặc null.</returns>
    Task<T> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Kiểm tra xem có bất kỳ entity nào tồn tại phù hợp với specification một cách bất đồng bộ hay không.
    /// </summary>
    /// <param name="specification">Specification để áp dụng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>True nếu có bất kỳ entity nào phù hợp với specification, ngược lại trả về false.</returns>
    Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    // --- Write Operations ---

    /// <summary>
    ///     Thêm một entity mới một cách bất đồng bộ.
    /// </summary>
    /// <param name="entity">Entity cần thêm.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Entity đã được thêm.</returns>
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Cập nhật một entity đã tồn tại một cách bất đồng bộ.
    /// </summary>
    /// <param name="entity">Entity cần cập nhật.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Xóa một entity một cách bất đồng bộ.
    /// </summary>
    /// <param name="entity">Entity cần xóa.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Xóa một entity theo ID một cách bất đồng bộ.
    /// </summary>
    /// <param name="id">ID của entity cần xóa.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
}