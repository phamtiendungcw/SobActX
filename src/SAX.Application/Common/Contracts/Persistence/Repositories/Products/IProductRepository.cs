using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity Product.
/// </summary>
public interface IProductRepository : IGenericRepository<Product>
{
    /// <summary>
    ///     Lấy danh sách các Product theo CategoryId một cách bất đồng bộ.
    /// </summary>
    /// <param name="categoryId">Id của ProductCategory.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Product theo CategoryId.</returns>
    Task<IReadOnlyList<Product>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm các Product theo từ khóa trong ProductName hoặc Description một cách bất đồng bộ.
    /// </summary>
    /// <param name="keyword">Từ khóa tìm kiếm.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Product phù hợp với từ khóa tìm kiếm.</returns>
    Task<IReadOnlyList<Product>> SearchProductsAsync(string keyword, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các Product nổi bật (ví dụ: sản phẩm bán chạy, sản phẩm mới) một cách bất đồng bộ.
    /// </summary>
    /// <param name="count">Số lượng sản phẩm nổi bật cần lấy.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Product nổi bật.</returns>
    Task<IReadOnlyList<Product>> GetFeaturedProductsAsync(int count, CancellationToken cancellationToken = default);
}