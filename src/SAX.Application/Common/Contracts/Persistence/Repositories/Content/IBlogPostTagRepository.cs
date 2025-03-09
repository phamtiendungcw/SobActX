using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

/// <summary>
///     Interface cho repository của entity BlogPostTag.
/// </summary>
public interface IBlogPostTagRepository : IGenericRepository<BlogPostTag>
{
    /// <summary>
    ///     Lấy danh sách các BlogPostTag theo BlogPostId một cách bất đồng bộ.
    /// </summary>
    /// <param name="blogPostId">Id của BlogPost.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách BlogPostTag theo BlogPostId.</returns>
    Task<IReadOnlyList<BlogPostTag>> GetBlogPostTagsByBlogPostAsync(Guid blogPostId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các BlogPostTag theo TagId một cách bất đồng bộ.
    /// </summary>
    /// <param name="tagId">Id của Tag.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách BlogPostTag theo TagId.</returns>
    Task<IReadOnlyList<BlogPostTag>> GetBlogPostTagsByTagAsync(Guid tagId, CancellationToken cancellationToken = default);
}