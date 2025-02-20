using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface ITagRepository : IGenericRepository<Tag>
{
    /// <summary>
    ///     Lấy tag theo tên tag (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<Tag?> GetTagByNameAsync(string tagName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các tags phổ biến nhất dựa trên số lượng bài viết blog sử dụng tag đó (cho cloud tags).
    /// </summary>
    Task<IReadOnlyList<Tag>> ListPopularTagsAsync(int count, CancellationToken cancellationToken = default);
}