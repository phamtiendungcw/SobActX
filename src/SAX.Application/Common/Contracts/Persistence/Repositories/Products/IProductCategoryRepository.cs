using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity ProductCategory.
/// </summary>
public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
{
    /// <summary>
    ///     Lấy một ProductCategory theo CategoryName một cách bất đồng bộ.
    /// </summary>
    /// <param name="categoryName">CategoryName của ProductCategory.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>ProductCategory nếu tìm thấy, ngược lại trả về null.</returns>
    Task<ProductCategory?> GetProductCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default);
}