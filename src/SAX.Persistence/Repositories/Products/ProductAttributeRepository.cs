using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity ProductAttribute.
/// </summary>
public class ProductAttributeRepository : GenericRepository<ProductAttribute>, IProductAttributeRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductAttributeRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductAttributeRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<ProductAttribute?> GetProductAttributeByNameAsync(string attributeName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductAttributes.FirstOrDefaultAsync(pa => pa.AttributeName == attributeName && !pa.IsDeleted && pa.IsActive, cancellationToken);
    }
}