using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

public class ProductReviewRepository : GenericRepository<ProductReview>, IProductReviewRepository
{
    public ProductReviewRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<ProductReview>> GetApprovedProductReviewsAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductReviews
            .Where(pr => pr.ProductId == productId && pr.IsApproved)
            .Include(pr => pr.Customer) // Eager load Customer
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductReview?> GetProductReviewByCustomerAndProductAsync(Guid customerId, Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductReviews
            .FirstOrDefaultAsync(pr => pr.CustomerId == customerId && pr.ProductId == productId, cancellationToken);
    }

    public async Task<IReadOnlyList<ProductReview>> GetPendingProductReviewsAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductReviews
            .Where(pr => pr.ProductId == productId && !pr.IsApproved)
            .Include(pr => pr.Customer) // Eager load Customer
            .ToListAsync(cancellationToken);
    }
}