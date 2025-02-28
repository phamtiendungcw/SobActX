using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
{
    public PromotionRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Promotion>> GetActivePromotionsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .Where(p => p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now)
            .ToListAsync(cancellationToken);
    }

    public async Task<Promotion?> GetPromotionByCouponCodeAsync(string couponCode, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .FirstOrDefaultAsync(p => p.CouponCode == couponCode, cancellationToken);
    }

    public async Task<IReadOnlyList<Promotion>> ListPromotionsByTypeAsync(string promotionType, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .Where(p => p.PromotionType == promotionType)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Promotion>> ListLatestPromotionsAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .OrderByDescending(p => p.StartDate) // Ví dụ: Order by StartDate để lấy "latest"
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}