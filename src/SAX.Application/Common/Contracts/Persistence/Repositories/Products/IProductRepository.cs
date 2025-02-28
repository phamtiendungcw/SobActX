using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    /// <summary>
    ///     Liệt kê các sản phẩm theo ID danh mục sản phẩm.
    /// </summary>
    Task<IReadOnlyList<Product>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm sản phẩm theo tên sản phẩm hoặc mô tả sản phẩm.
    /// </summary>
    Task<IReadOnlyList<Product>> SearchProductsByNameAsync(string productName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các sản phẩm nổi bật (ví dụ: sản phẩm mới, sản phẩm giảm giá, sản phẩm bán chạy nhất - cần thêm trường
    ///     IsFeatured hoặc logic xác định sản phẩm nổi bật).
    /// </summary>
    Task<IReadOnlyList<Product>> GetFeaturedProductsAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy sản phẩm theo SKU (Stock Keeping Unit - mã sản phẩm - cho mục đích kiểm tra tính duy nhất hoặc tìm kiếm nhanh).
    /// </summary>
    Task<Product?> GetProductBySkuAsync(string sku, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các sản phẩm mới nhất (cho trang sản phẩm mới).
    /// </summary>
    Task<IReadOnlyList<Product>> ListLatestProductsAsync(int count, CancellationToken cancellationToken = default);
}