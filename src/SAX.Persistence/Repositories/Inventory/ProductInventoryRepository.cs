using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Domain.Entities.Inventory;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Inventory;

/// <summary>
///     Repository cho entity ProductInventory.
/// </summary>
public class ProductInventoryRepository : GenericRepository<ProductInventory>, IProductInventoryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ProductInventoryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ProductInventoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<ProductInventory?> GetProductInventoryByProductAndWarehouseAsync(Guid productId, Guid warehouseId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductInventories.FirstOrDefaultAsync(pi => pi.ProductId == productId && pi.WarehouseId == warehouseId && !pi.IsDeleted && pi.IsActive, cancellationToken);
    }
}