using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Products;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Domain.Entities.Products;

public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
{
    public ProductBrandRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ProductBrand?> GetProductBrandByNameAsync(string brandName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductBrands.FirstOrDefaultAsync(pb => pb.BrandName == brandName, cancellationToken);
    }

    public async Task<IReadOnlyList<ProductBrand>> ListProductBrandsWithProductCountsAsync(CancellationToken cancellationToken = default)
    {
        // Code mẫu này chỉ trả về danh sách ProductBrands đơn giản, bạn cần tùy chỉnh để tính Product Counts
        return await ListAllAsync(cancellationToken);
    }
}