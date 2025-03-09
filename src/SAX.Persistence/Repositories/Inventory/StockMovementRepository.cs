using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

/// <summary>
///     Repository cho entity StockMovement.
/// </summary>
public class StockMovementRepository : GenericRepository<StockMovement>, IStockMovementRepository
{
    /// <summary>
    ///     Khởi tạo một instance của StockMovementRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public StockMovementRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<StockMovement>> GetStockMovementsByProductInventoryAsync(Guid productInventoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.StockMovements.Where(sm => sm.ProductInventoryId == productInventoryId && !sm.IsDeleted && sm.IsActive).ToListAsync(cancellationToken);
    }
}