using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity ProductBrand.
/// </summary>
public interface IProductBrandRepository : IGenericRepository<ProductBrand>
{
    /// <summary>
    ///     Lấy một ProductBrand theo BrandName một cách bất đồng bộ.
    /// </summary>
    /// <param name="brandName">BrandName của ProductBrand.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>ProductBrand nếu tìm thấy, ngược lại trả về null.</returns>
    Task<ProductBrand?> GetProductBrandByNameAsync(string brandName, CancellationToken cancellationToken = default);
}