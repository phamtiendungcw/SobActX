using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

public interface IProductInventoryRepository : IGenericRepository<ProductInventory>
{
    /// <summary>
    ///     Lấy thông tin tồn kho của sản phẩm tại một kho cụ thể.
    /// </summary>
    Task<ProductInventory?> GetProductInventoryByProductAndWarehouseAsync(Guid productId, Guid warehouseId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các sản phẩm có số lượng tồn kho thấp hơn một ngưỡng nhất định (cho cảnh báo tồn kho).
    /// </summary>
    Task<IReadOnlyList<ProductInventory>> GetLowStockProductsAsync(int threshold, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê thông tin tồn kho của một sản phẩm trên tất cả các kho (cho trang chi tiết sản phẩm).
    /// </summary>
    Task<IReadOnlyList<ProductInventory>> ListProductInventoriesForProductAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê thông tin tồn kho tại một kho cụ thể cho tất cả các sản phẩm (cho trang quản lý kho).
    /// </summary>
    Task<IReadOnlyList<ProductInventory>> ListProductInventoriesForWarehouseAsync(Guid warehouseId, CancellationToken cancellationToken = default);
}