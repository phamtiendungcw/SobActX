using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

public class ProductAttributeRepository : GenericRepository<ProductAttribute>, IProductAttributeRepository
{
    public ProductAttributeRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ProductAttribute?> GetProductAttributeByNameAsync(string attributeName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductAttributes.FirstOrDefaultAsync(pa => pa.AttributeName == attributeName, cancellationToken);
    }
}