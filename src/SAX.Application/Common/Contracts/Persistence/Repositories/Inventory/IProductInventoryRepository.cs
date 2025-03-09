using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

/// <summary>
///     Interface cho repository của entity ProductInventory.
/// </summary>
public interface IProductInventoryRepository : IGenericRepository<ProductInventory>
{
    /// <summary>
    ///     Lấy ProductInventory theo ProductId và WarehouseId một cách bất đồng bộ.
    /// </summary>
    /// <param name="productId">Id của sản phẩm.</param>
    /// <param name="warehouseId">Id của kho hàng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>ProductInventory nếu tìm thấy, ngược lại trả về null.</returns>
    Task<ProductInventory?> GetProductInventoryByProductAndWarehouseAsync(Guid productId, Guid warehouseId, CancellationToken cancellationToken = default);
}