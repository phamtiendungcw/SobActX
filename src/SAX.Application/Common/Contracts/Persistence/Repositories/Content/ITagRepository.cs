using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

/// <summary>
///     Interface cho repository của entity Tag.
/// </summary>
public interface ITagRepository : IGenericRepository<Tag>
{
    /// <summary>
    ///     Lấy một tag theo tên tag một cách bất đồng bộ.
    /// </summary>
    /// <param name="tagName">Tên của tag.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Tag nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Tag?> GetTagByNameAsync(string tagName, CancellationToken cancellationToken = default);
}