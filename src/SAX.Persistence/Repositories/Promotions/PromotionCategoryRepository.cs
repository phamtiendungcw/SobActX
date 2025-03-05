using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

public class PromotionCategoryRepository : GenericRepository<PromotionCategory>, IPromotionCategoryRepository
{
    public PromotionCategoryRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<PromotionCategory>> ListPromotionCategoriesForPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionCategories
            .Where(pc => pc.PromotionId == promotionId)
            .Include(pc => pc.ProductCategory) // Eager load Promotion và ProductCategory
            .Include(pc => pc.Promotion)
            .ToListAsync(cancellationToken);
    }

    public async Task<PromotionCategory?> GetPromotionCategoryByPromotionAndCategoryAsync(Guid promotionId, Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionCategories
            .FirstOrDefaultAsync(pc => pc.PromotionId == promotionId && pc.ProductCategoryId == categoryId, cancellationToken);
    }

    public async Task<bool> IsCategoryInPromotionAsync(Guid productCategoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionCategories
            .AnyAsync(pc => pc.ProductCategoryId == productCategoryId && pc.Promotion != null && pc.Promotion.StartDate <= DateTime.Now && pc.Promotion.EndDate >= DateTime.Now, cancellationToken);
    }
}