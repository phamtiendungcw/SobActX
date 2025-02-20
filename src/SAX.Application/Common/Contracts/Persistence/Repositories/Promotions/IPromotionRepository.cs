using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

public interface IPromotionRepository : IGenericRepository<Promotion>
{
    /// <summary>
    ///     Liệt kê các promotions đang hoạt động (trong thời gian hiệu lực và có thể có coupon code).
    /// </summary>
    Task<IReadOnlyList<Promotion>> GetActivePromotionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy promotion theo coupon code (cho việc áp dụng mã giảm giá).
    /// </summary>
    Task<Promotion?> GetPromotionByCouponCodeAsync(string couponCode, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các promotions theo loại promotion (ví dụ: Percentage, FixedAmount).
    /// </summary>
    Task<IReadOnlyList<Promotion>> ListPromotionsByTypeAsync(string promotionType, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các promotions mới nhất (cho trang khuyến mãi hoặc dashboard marketing).
    /// </summary>
    Task<IReadOnlyList<Promotion>> ListLatestPromotionsAsync(int count, CancellationToken cancellationToken = default);
}