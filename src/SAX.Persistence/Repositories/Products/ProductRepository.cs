using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Product>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category) // Eager load Category và Brand
            .Include(p => p.Brand)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetFeaturedProductsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Cần implement logic để xác định "Featured Products" (ví dụ: thêm trường IsFeatured vào Entity Product)
        // Code mẫu này chỉ trả về latest products dựa trên ID (không đúng logic "Featured Products")
        return await _dbContext.Products
            .OrderByDescending(p => p.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> ListLatestProductsAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .OrderByDescending(p => p.Id) // Ví dụ: Order by ID để lấy "latest"
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetProductBySkuAsync(string sku, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.SKU == sku, cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> SearchProductsByNameAsync(string productName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .Where(p => p.ProductName.Contains(productName) || p.Description.Contains(productName))
            .Include(p => p.Category) // Eager load Category và Brand
            .Include(p => p.Brand)
            .ToListAsync(cancellationToken);
    }
}