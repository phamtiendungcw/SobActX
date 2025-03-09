using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
    /// <summary>
    ///     Lấy danh sách các bài đăng blog đã được xuất bản một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách các bài đăng blog đã được xuất bản.</returns>
    Task<IReadOnlyList<BlogPost>> GetPublishedBlogPostsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy một bài đăng blog theo slug một cách bất đồng bộ.
    /// </summary>
    /// <param name="slug">Slug của bài đăng blog.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Bài đăng blog nếu tìm thấy, ngược lại trả về null.</returns>
    Task<BlogPost?> GetBlogPostBySlugAsync(string slug, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm các bài đăng blog theo từ khóa trong tiêu đề hoặc nội dung một cách bất đồng bộ.
    /// </summary>
    /// <param name="keyword">Từ khóa tìm kiếm.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách các bài đăng blog phù hợp với từ khóa tìm kiếm.</returns>
    Task<IReadOnlyList<BlogPost>> SearchBlogPostsAsync(string keyword, CancellationToken cancellationToken = default);
}