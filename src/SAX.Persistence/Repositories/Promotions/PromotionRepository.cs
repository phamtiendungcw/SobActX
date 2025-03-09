using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

/// <summary>
///     Repository cho entity Promotion.
/// </summary>
public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
{
    /// <summary>
    ///     Khởi tạo một instance của PromotionRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public PromotionRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Promotion>> GetActivePromotionsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .Where(p => p.StartDate <= DateTime.UtcNow && p.EndDate >= DateTime.UtcNow && !p.IsDeleted && p.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Promotion>> GetPromotionsByTypeAsync(PromotionType promotionType, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Promotions
            .Where(p => p.PromotionType == promotionType && !p.IsDeleted && p.IsActive)
            .ToListAsync(cancellationToken);
    }
}