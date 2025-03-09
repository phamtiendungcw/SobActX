using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

/// <summary>
///     Interface cho repository của entity PromotionProduct.
/// </summary>
public interface IPromotionProductRepository : IGenericRepository<PromotionProduct>
{
    /// <summary>
    ///     Lấy danh sách các PromotionProduct theo PromotionId một cách bất đồng bộ.
    /// </summary>
    /// <param name="promotionId">Id của Promotion.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách PromotionProduct theo PromotionId.</returns>
    Task<IReadOnlyList<PromotionProduct>> GetPromotionProductsByPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default);
}