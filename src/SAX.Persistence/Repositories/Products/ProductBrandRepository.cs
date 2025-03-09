using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

/// <summary>
///     Repository cho entity ProductBrand.
/// </summary>
public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductBrandRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductBrandRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<ProductBrand?> GetProductBrandByNameAsync(string brandName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductBrands.FirstOrDefaultAsync(pb => pb.BrandName == brandName && !pb.IsDeleted && pb.IsActive, cancellationToken);
    }
}