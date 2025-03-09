using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity ProductReview.
/// </summary>
public interface IProductReviewRepository : IGenericRepository<ProductReview>
{
    /// <summary>
    ///     Lấy danh sách các ProductReview theo ProductId một cách bất đồng bộ.
    /// </summary>
    /// <param name="productId">Id của Product.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách ProductReview theo ProductId.</returns>
    Task<IReadOnlyList<ProductReview>> GetProductReviewsByProductAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các ProductReview đã được approve một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách ProductReview đã được approve.</returns>
    Task<IReadOnlyList<ProductReview>> GetApprovedProductReviewsAsync(CancellationToken cancellationToken = default);
}