using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity ProductReview.
/// </summary>
public class ProductReviewRepository : GenericRepository<ProductReview>, IProductReviewRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductReviewRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductReviewRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ProductReview>> GetProductReviewsByProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductReviews
            .Where(pr => pr.ProductId == productId && !pr.IsDeleted && pr.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ProductReview>> GetApprovedProductReviewsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductReviews
            .Where(pr => pr.IsApproved && !pr.IsDeleted && pr.IsActive)
            .ToListAsync(cancellationToken);
    }
}