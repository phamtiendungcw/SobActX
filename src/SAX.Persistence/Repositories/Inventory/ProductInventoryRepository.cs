using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

public class ProductInventoryRepository : GenericRepository<ProductInventory>, IProductInventoryRepository
{
    public ProductInventoryRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<ProductInventory?> GetProductInventoryByProductAndWarehouseAsync(Guid productId, Guid warehouseId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductInventories
            .FirstOrDefaultAsync(pi => pi.ProductId == productId && pi.WarehouseId == warehouseId, cancellationToken);
    }

    public async Task<IReadOnlyList<ProductInventory>> GetLowStockProductsAsync(int threshold, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductInventories
            .Where(pi => pi.QuantityAvailable < threshold)
            .Include(pi => pi.Product) // Eager load Product và Warehouse
            .Include(pi => pi.Warehouse)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProductInventory>> ListProductInventoriesForProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductInventories
            .Where(pi => pi.ProductId == productId)
            .Include(pi => pi.Warehouse) // Eager load Warehouse
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProductInventory>> ListProductInventoriesForWarehouseAsync(Guid warehouseId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductInventories
            .Where(pi => pi.WarehouseId == warehouseId)
            .Include(pi => pi.Product) // Eager load Product
            .ToListAsync(cancellationToken);
    }
}