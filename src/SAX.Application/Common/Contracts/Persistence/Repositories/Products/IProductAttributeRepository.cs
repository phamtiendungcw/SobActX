using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity ProductAttribute.
/// </summary>
public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
{
    /// <summary>
    ///     Lấy một ProductAttribute theo AttributeName một cách bất đồng bộ.
    /// </summary>
    /// <param name="attributeName">AttributeName của ProductAttribute.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>ProductAttribute nếu tìm thấy, ngược lại trả về null.</returns>
    Task<ProductAttribute?> GetProductAttributeByNameAsync(string attributeName, CancellationToken cancellationToken = default);
}