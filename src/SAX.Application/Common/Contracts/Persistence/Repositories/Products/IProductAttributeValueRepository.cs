using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

public interface IProductAttributeValueRepository : IGenericRepository<ProductAttributeValue>
{
    /// <summary>
    ///     Liệt kê các product attribute values của một sản phẩm cụ thể.
    /// </summary>
    Task<IReadOnlyList<ProductAttributeValue>> ListProductAttributeValuesForProductAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy product attribute value theo giá trị và ID attribute (cho mục đích kiểm tra tính duy nhất hoặc tìm kiếm theo
    ///     giá trị attribute).
    /// </summary>
    Task<ProductAttributeValue?> GetProductAttributeValueByValueAndAttributeIdAsync(string value, Guid attributeId, CancellationToken cancellationToken = default);
}