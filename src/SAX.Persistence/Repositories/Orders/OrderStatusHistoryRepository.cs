using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity OrderStatusHistory.
/// </summary>
public class OrderStatusHistoryRepository : GenericRepository<OrderStatusHistory>, IOrderStatusHistoryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của OrderStatusHistoryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public OrderStatusHistoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<OrderStatusHistory>> GetOrderStatusHistoriesByOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.OrderStatusHistories
            .Where(osh => osh.OrderId == orderId && !osh.IsDeleted && osh.IsActive)
            .ToListAsync(cancellationToken);
    }
}