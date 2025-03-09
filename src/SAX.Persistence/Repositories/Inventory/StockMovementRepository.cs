using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;

public class StockMovementRepository : GenericRepository<StockMovement>, IStockMovementRepository
{
    public StockMovementRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<StockMovement>> ListStockMovementsForProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.StockMovements
            .Include(sm => sm.ProductInventory) // Eager load ProductInventory và Product
            .ThenInclude(pi => pi.Product)
            .Where(sm => sm.ProductInventory != null && sm.ProductInventory.ProductId == productId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StockMovement>> ListStockMovementsForWarehouseAsync(Guid warehouseId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.StockMovements
            .Include(sm => sm.ProductInventory) // Eager load ProductInventory và Warehouse
            .ThenInclude(pi => pi.Warehouse)
            .Where(sm => sm.ProductInventory != null && sm.ProductInventory.WarehouseId == warehouseId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<StockMovement>> GetStockMovementSummaryAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.StockMovements
            .Where(sm => sm.MovementDate >= startDate && sm.MovementDate <= endDate)
            .ToListAsync(cancellationToken);
    }
}