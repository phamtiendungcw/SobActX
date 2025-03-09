using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity Product.
/// </summary>
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Product>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .Where(p => p.CategoryId == categoryId && !p.IsDeleted && p.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Product>> SearchProductsAsync(string keyword, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .Where(p => (p.ProductName.Contains(keyword) || p.Description!.Contains(keyword)) && !p.IsDeleted && p.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Product>> GetFeaturedProductsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Logic lấy sản phẩm nổi bật có thể phức tạp hơn, ví dụ:
        // - Lấy sản phẩm bán chạy nhất
        // - Lấy sản phẩm mới nhất
        // - Lấy sản phẩm được đánh giá cao nhất
        // Chỉ lấy `count` sản phẩm đầu tiên
        return await _dbContext.Products
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}