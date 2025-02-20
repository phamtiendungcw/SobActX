using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductBrandRepository : IGenericRepository<ProductBrand>
{
    /// <summary>
    ///     Lấy thương hiệu sản phẩm theo tên thương hiệu (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<ProductBrand?> GetProductBrandByNameAsync(string brandName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các thương hiệu sản phẩm, bao gồm cả số lượng sản phẩm trong mỗi thương hiệu (cho bộ lọc thương hiệu hoặc
    ///     dashboard).
    /// </summary>
    Task<IReadOnlyList<ProductBrand>> ListProductBrandsWithProductCountsAsync(CancellationToken cancellationToken = default);
}