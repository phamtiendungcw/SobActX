using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

/// <summary>
///     Repository cho entity BlogPostTag.
/// </summary>
public class BlogPostTagRepository : GenericRepository<BlogPostTag>, IBlogPostTagRepository
{
    /// <summary>
    ///     Khởi tạo một instance của BlogPostTagRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public BlogPostTagRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<BlogPostTag>> GetBlogPostTagsByBlogPostAsync(Guid blogPostId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPostsTags
            .Where(bpt => bpt.BlogPostId == blogPostId && !bpt.IsDeleted && bpt.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<BlogPostTag>> GetBlogPostTagsByTagAsync(Guid tagId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPostsTags
            .Where(bpt => bpt.TagId == tagId && !bpt.IsDeleted && bpt.IsActive)
            .ToListAsync(cancellationToken);
    }
}