using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
{
    /// <summary>
    ///     Lấy danh mục sản phẩm theo tên danh mục (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<ProductCategory?> GetProductCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các danh mục sản phẩm, bao gồm cả số lượng sản phẩm trong mỗi danh mục (cho menu danh mục hoặc dashboard).
    /// </summary>
    Task<IReadOnlyList<ProductCategory>> ListProductCategoriesWithProductCountsAsync(CancellationToken cancellationToken = default);
}