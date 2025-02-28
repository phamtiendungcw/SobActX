using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

public class ProductAttributeValueRepository : GenericRepository<ProductAttributeValue>, IProductAttributeValueRepository
{
    public ProductAttributeValueRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<ProductAttributeValue>> ListProductAttributeValuesForProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductAttributeValues
            .Where(pav => pav.ProductId == productId)
            .Include(pav => pav.ProductAttribute) // Eager load Attribute
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductAttributeValue?> GetProductAttributeValueByValueAndAttributeIdAsync(string value, Guid attributeId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductAttributeValues
            .FirstOrDefaultAsync(pav => pav.Value == value && pav.ProductAttributeId == attributeId, cancellationToken);
    }
}