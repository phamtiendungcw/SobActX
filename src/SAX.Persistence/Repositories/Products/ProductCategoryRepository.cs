using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity ProductCategory.
/// </summary>
public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductCategoryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductCategoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<ProductCategory?> GetProductCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductCategories.FirstOrDefaultAsync(pc => pc.CategoryName == categoryName && !pc.IsDeleted && pc.IsActive, cancellationToken);
    }
}