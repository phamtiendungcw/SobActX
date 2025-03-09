using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

/// <summary>
///     Repository cho entity PromotionProduct.
/// </summary>
public class PromotionProductRepository : GenericRepository<PromotionProduct>, IPromotionProductRepository
{
    /// <summary>
    ///     Khởi tạo một instance của PromotionProductRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public PromotionProductRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PromotionProduct>> GetPromotionProductsByPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionsProducts
            .Where(pp => pp.PromotionId == promotionId && !pp.IsDeleted && pp.IsActive)
            .ToListAsync(cancellationToken);
    }
}