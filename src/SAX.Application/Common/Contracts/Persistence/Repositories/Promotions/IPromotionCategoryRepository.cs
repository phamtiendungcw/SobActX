// File: Application/Common/Contracts/Persistence/Repositories/Promotions/IPromotionCategoryRepository.cs

using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

/// <summary>
///     Interface cho repository của entity PromotionCategory.
/// </summary>
public interface IPromotionCategoryRepository : IGenericRepository<PromotionCategory>
{
    /// <summary>
    ///     Lấy danh sách các PromotionCategory theo PromotionId một cách bất đồng bộ.
    /// </summary>
    /// <param name="promotionId">Id của Promotion.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách PromotionCategory theo PromotionId.</returns>
    Task<IReadOnlyList<PromotionCategory>> GetPromotionCategoriesByPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default);
}