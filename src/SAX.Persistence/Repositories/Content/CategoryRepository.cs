using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName, cancellationToken);
    }

    public async Task<IReadOnlyList<Category>> ListCategoriesWithBlogPostCountsAsync(CancellationToken cancellationToken = default)
    {
        // Truy vấn phức tạp hơn, có thể sử dụng raw SQL hoặc LINQ to Entities nâng cao
        // Code mẫu này chỉ trả về danh sách Category đơn giản, bạn cần tùy chỉnh để tính BlogPost counts
        return await ListAllAsync(cancellationToken);
    }
}