using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity ProductAttributeValue.
/// </summary>
public class ProductAttributeValueRepository : GenericRepository<ProductAttributeValue>, IProductAttributeValueRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductAttributeValueRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductAttributeValueRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ProductAttributeValue>> GetProductAttributeValuesByProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductAttributeValues
            .Where(pav => pav.ProductId == productId && !pav.IsDeleted && pav.IsActive)
            .ToListAsync(cancellationToken);
    }
}