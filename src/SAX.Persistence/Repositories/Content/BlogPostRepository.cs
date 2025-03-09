using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<BlogPost>> GetBlogPostsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts
            .Where(bp => bp.CategoryId == categoryId)
            .Include(bp => bp.Author) // Eager load Author và Category
            .Include(bp => bp.Category)
            .ToListAsync(cancellationToken);
    }

    public async Task<BlogPost?> GetBlogPostBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts.FirstOrDefaultAsync(bp => bp.Slug == slug, cancellationToken);
    }

    public async Task<IReadOnlyList<BlogPost>> ListLatestBlogPostsAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts
            .OrderByDescending(bp => bp.PublishedAt)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<BlogPost>> ListPopularBlogPostsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Cần implement logic để xác định độ phổ biến (ví dụ: dựa trên lượt xem, tương tác, v.v.)
        // Code mẫu này chỉ trả về latest blog posts
        return await ListLatestBlogPostsAsync(count, cancellationToken);
    }

    public async Task<IReadOnlyList<BlogPost>> SearchBlogPostsAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogPosts
            .Where(bp => bp.ContentBody != null && (bp.Title.Contains(searchTerm) || bp.ContentBody.Contains(searchTerm)))
            .ToListAsync(cancellationToken);
    }
}