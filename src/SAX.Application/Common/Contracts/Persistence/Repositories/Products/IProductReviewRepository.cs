using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductReviewRepository : IGenericRepository<ProductReview>
{
    /// <summary>
    ///     Liệt kê các product reviews đã được duyệt (cho trang chi tiết sản phẩm).
    /// </summary>
    Task<IReadOnlyList<ProductReview>> GetApprovedProductReviewsAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các product reviews chưa được duyệt (cho trang quản lý admin).
    /// </summary>
    Task<IReadOnlyList<ProductReview>> GetPendingProductReviewsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy product review theo customer ID và product ID (cho mục đích kiểm tra xem khách hàng đã review sản phẩm hay
    ///     chưa).
    /// </summary>
    Task<ProductReview?> GetProductReviewByCustomerAndProductAsync(Guid customerId, Guid productId, CancellationToken cancellationToken = default);
}