using SAX.Domain.Entities.Inventory;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    /// <summary>
    ///     Lấy kho theo tên kho (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<Warehouse?> GetWarehouseByNameAsync(string warehouseName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các kho theo quốc gia (nếu quản lý kho theo khu vực địa lý).
    /// </summary>
    Task<IReadOnlyList<Warehouse>> ListWarehousesByCountryAsync(string country, CancellationToken cancellationToken = default);
}