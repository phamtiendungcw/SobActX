using SAX.Domain;
using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

/// <summary>
///     Interface cho repository của entity Promotion.
/// </summary>
public interface IPromotionRepository : IGenericRepository<Promotion>
{
    /// <summary>
    ///     Lấy danh sách các Promotion đang active một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Promotion đang active.</returns>
    Task<IReadOnlyList<Promotion>> GetActivePromotionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các Promotion theo PromotionType một cách bất đồng bộ.
    /// </summary>
    /// <param name="promotionType">PromotionType để lọc.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Promotion theo PromotionType.</returns>
    Task<IReadOnlyList<Promotion>> GetPromotionsByTypeAsync(PromotionType promotionType, CancellationToken cancellationToken = default);
}