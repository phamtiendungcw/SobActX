using SAX.Domain.Entities.Promotions;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;

public interface IPromotionCategoryRepository : IGenericRepository<PromotionCategory>
{
    /// <summary>
    ///     Liệt kê các promotion categories thuộc về một promotion cụ thể.
    /// </summary>
    Task<IReadOnlyList<PromotionCategory>> ListPromotionCategoriesForPromotionAsync(Guid promotionId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Kiểm tra xem một danh mục sản phẩm cụ thể có đang được áp dụng promotion nào không.
    /// </summary>
    Task<bool> IsCategoryInPromotionAsync(Guid productCategoryId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy promotion category theo promotion ID và category ID (cho mục đích kiểm tra trùng lặp hoặc lấy thông tin chi
    ///     tiết).
    /// </summary>
    Task<PromotionCategory?> GetPromotionCategoryByPromotionAndCategoryAsync(Guid promotionId, Guid categoryId, CancellationToken cancellationToken = default);
}