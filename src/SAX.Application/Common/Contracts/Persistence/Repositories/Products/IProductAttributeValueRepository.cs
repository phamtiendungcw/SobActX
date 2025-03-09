using SAX.Domain.Entities.Products;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Products;

/// <summary>
///     Interface cho repository của entity ProductAttributeValue.
/// </summary>
public interface IProductAttributeValueRepository : IGenericRepository<ProductAttributeValue>
{
    /// <summary>
    ///     Lấy danh sách các ProductAttributeValue theo ProductId một cách bất đồng bộ.
    /// </summary>
    /// <param name="productId">Id của Product.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách ProductAttributeValue theo ProductId.</returns>
    Task<IReadOnlyList<ProductAttributeValue>> GetProductAttributeValuesByProductAsync(Guid productId, CancellationToken cancellationToken = default);
}