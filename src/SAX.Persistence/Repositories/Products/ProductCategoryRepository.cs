using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;

public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<ProductCategory?> GetProductCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.CategoryName == categoryName, cancellationToken);
    }

    public async Task<IReadOnlyList<ProductCategory>> ListProductCategoriesWithProductCountsAsync(CancellationToken cancellationToken = default)
    {
        // Code mẫu này chỉ trả về danh sách ProductCategories đơn giản, bạn cần tùy chỉnh để tính Product Counts
        return await ListAllAsync(cancellationToken);
    }
}