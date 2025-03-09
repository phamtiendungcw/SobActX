using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

/// <summary>
///     Interface cho repository của entity Warehouse.
/// </summary>
public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    /// <summary>
    ///     Lấy một kho hàng theo tên kho một cách bất đồng bộ.
    /// </summary>
    /// <param name="warehouseName">Tên kho hàng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Kho hàng nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Warehouse?> GetWarehouseByNameAsync(string warehouseName, CancellationToken cancellationToken = default);
}