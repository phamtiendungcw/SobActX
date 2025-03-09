using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

/// <summary>
///     Repository cho entity Warehouse.
/// </summary>
public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    /// <summary>
    ///     Khởi tạo một instance của WarehouseRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public WarehouseRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Warehouse?> GetWarehouseByNameAsync(string warehouseName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Warehouses.FirstOrDefaultAsync(w => w.WarehouseName == warehouseName && !w.IsDeleted && w.IsActive, cancellationToken);
    }
}