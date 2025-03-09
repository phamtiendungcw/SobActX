using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Domain.Entities.Promotions;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Promotions;

/// <summary>
///     Repository cho entity PromotionCategory.
/// </summary>
public class PromotionCategoryRepository : GenericRepository<PromotionCategory>, IPromotionCategoryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của PromotionCategoryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public PromotionCategoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PromotionCategory>> GetPromotionCategoriesByPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PromotionsCategories
            .Where(pc => pc.PromotionId == promotionId && !pc.IsDeleted && pc.IsActive)
            .ToListAsync(cancellationToken);
    }
}