using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

public class PromotionProductRepository : GenericRepository<PromotionProduct>, IPromotionProductRepository
{
    public PromotionProductRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<PromotionProduct>> ListPromotionProductsForPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionsProducts
            .Where(pp => pp.PromotionId == promotionId)
            .Include(pp => pp.Product) // Eager load Promotion và Product
            .Include(pp => pp.Promotion)
            .ToListAsync(cancellationToken);
    }

    public async Task<PromotionProduct?> GetPromotionProductByPromotionAndProductAsync(Guid promotionId, Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionsProducts
            .FirstOrDefaultAsync(pp => pp.PromotionId == promotionId && pp.ProductId == productId, cancellationToken);
    }

    public async Task<bool> IsProductInPromotionAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionsProducts
            .AnyAsync(pp => pp.ProductId == productId && pp.Promotion != null && pp.Promotion.StartDate <= DateTime.Now && pp.Promotion.EndDate >= DateTime.Now, cancellationToken);
    }
}