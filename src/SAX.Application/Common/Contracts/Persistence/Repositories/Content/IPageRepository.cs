using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface IPageRepository : IGenericRepository<Page>
{
    /// <summary>
    ///     Lấy trang theo slug (cho việc hiển thị trang đơn).
    /// </summary>
    Task<Page?> GetPageBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các trang được xuất bản gần đây nhất (cho sidebar hoặc phần trang chủ).
    /// </summary>
    Task<IReadOnlyList<Page>> ListLatestPublishedPagesAsync(int count, CancellationToken cancellationToken = default);
}