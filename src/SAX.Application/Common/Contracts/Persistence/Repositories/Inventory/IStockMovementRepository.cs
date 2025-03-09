using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

/// <summary>
///     Interface cho repository của entity StockMovement.
/// </summary>
public interface IStockMovementRepository : IGenericRepository<StockMovement>
{
    /// <summary>
    ///     Lấy danh sách StockMovements theo ProductInventoryId một cách bất đồng bộ.
    /// </summary>
    /// <param name="productInventoryId">Id của ProductInventory.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách StockMovements theo ProductInventoryId.</returns>
    Task<IReadOnlyList<StockMovement>> GetStockMovementsByProductInventoryAsync(Guid productInventoryId, CancellationToken cancellationToken = default);
}