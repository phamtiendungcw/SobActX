using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

public interface IPromotionProductRepository : IGenericRepository<PromotionProduct>
{
    /// <summary>
    ///     Liệt kê các promotion products thuộc về một promotion cụ thể.
    /// </summary>
    Task<IReadOnlyList<PromotionProduct>> ListPromotionProductsForPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Kiểm tra xem một sản phẩm cụ thể có đang được áp dụng promotion nào không.
    /// </summary>
    Task<bool> IsProductInPromotionAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy promotion product theo promotion ID và product ID (cho mục đích kiểm tra trùng lặp hoặc lấy thông tin chi
    ///     tiết).
    /// </summary>
    Task<PromotionProduct?> GetPromotionProductByPromotionAndProductAsync(Guid promotionId, Guid productId, CancellationToken cancellationToken = default);
}