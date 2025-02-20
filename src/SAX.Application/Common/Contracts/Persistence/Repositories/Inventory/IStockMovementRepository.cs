using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

public interface IStockMovementRepository : IGenericRepository<StockMovement>
{
    /// <summary>
    ///     Liệt kê lịch sử nhập xuất kho của một sản phẩm cụ thể.
    /// </summary>
    Task<IReadOnlyList<StockMovement>> ListStockMovementsForProductAsync(Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê lịch sử nhập xuất kho tại một kho cụ thể.
    /// </summary>
    Task<IReadOnlyList<StockMovement>> ListStockMovementsForWarehouseAsync(Guid warehouseId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy báo cáo tổng hợp nhập xuất kho trong một khoảng thời gian (cho báo cáo kho).
    /// </summary>
    Task<IReadOnlyList<StockMovement>> GetStockMovementSummaryAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}