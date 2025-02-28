using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Warehouse?> GetWarehouseByNameAsync(string warehouseName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Warehouses.FirstOrDefaultAsync(w => w.WarehouseName == warehouseName, cancellationToken);
    }

    public async Task<IReadOnlyList<Warehouse>> ListWarehousesByCountryAsync(string country, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Warehouses
            .Where(w => w.Address != null && w.Address.Country == country)
            .Include(w => w.Address) // Eager load Address để lọc theo Country
            .ToListAsync(cancellationToken);
    }
}