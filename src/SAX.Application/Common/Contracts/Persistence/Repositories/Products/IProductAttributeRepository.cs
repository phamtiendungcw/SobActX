using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
{
    /// <summary>
    ///     Lấy product attribute theo tên attribute (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<ProductAttribute?> GetProductAttributeByNameAsync(string attributeName, CancellationToken cancellationToken = default);
}