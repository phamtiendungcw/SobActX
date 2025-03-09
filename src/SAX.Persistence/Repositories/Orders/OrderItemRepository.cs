using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity OrderItem.
/// </summary>
public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    /// <summary>
    ///     Khởi tạo một instance của OrderItemRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public OrderItemRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<OrderItem>> GetOrderItemsByOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.OrderItems
            .Where(oi => oi.OrderId == orderId && !oi.IsDeleted && oi.IsActive)
            .ToListAsync(cancellationToken);
    }
}