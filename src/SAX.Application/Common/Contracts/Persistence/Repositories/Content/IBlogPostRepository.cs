using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
    /// <summary>
    ///     Lấy danh sách bài viết blog theo ID danh mục.
    /// </summary>
    Task<IReadOnlyList<BlogPost>> GetBlogPostsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách bài viết blog theo slug (cho việc hiển thị bài viết đơn).
    /// </summary>
    Task<BlogPost?> GetBlogPostBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các bài viết blog mới nhất (cho trang chủ hoặc trang blog).
    /// </summary>
    Task<IReadOnlyList<BlogPost>> ListLatestBlogPostsAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các bài viết blog phổ biến nhất (dựa trên số lượt xem hoặc tương tác - cần thêm trường Count vào Entity nếu
    ///     muốn thống kê).
    /// </summary>
    Task<IReadOnlyList<BlogPost>> ListPopularBlogPostsAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm bài viết blog theo từ khóa trong tiêu đề hoặc nội dung.
    /// </summary>
    Task<IReadOnlyList<BlogPost>> SearchBlogPostsAsync(string searchTerm, CancellationToken cancellationToken = default);
}