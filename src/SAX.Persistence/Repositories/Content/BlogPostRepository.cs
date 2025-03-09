using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

/// <summary>
///     Repository cho entity BlogPost.
/// </summary>
public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
    /// <summary>
    ///     Khởi tạo một instance của BlogPostRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public BlogPostRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<BlogPost>> GetPublishedBlogPostsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts.Where(bp => bp.PublishedAt != null && bp.PublishedAt <= DateTime.UtcNow && !bp.IsDeleted && bp.IsActive).ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<BlogPost?> GetBlogPostBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts.FirstOrDefaultAsync(bp => bp.Slug == slug && !bp.IsDeleted && bp.IsActive, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<BlogPost>> SearchBlogPostsAsync(string keyword, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts.Where(bp => (bp.Title.Contains(keyword) || bp.ContentBody!.Contains(keyword)) && !bp.IsDeleted && bp.IsActive).ToListAsync(cancellationToken);
    }
}