using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<OrderItem>> ListOrderItemsForOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .Include(oi => oi.Product) // Eager load Product
            .ToListAsync(cancellationToken);
    }

    public async Task<OrderItem?> GetOrderItemDetailsWithProductAsync(Guid orderItemId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.OrderItems
            .Where(oi => oi.Id == orderItemId)
            .Include(oi => oi.Product) // Eager load Product
            .FirstOrDefaultAsync(cancellationToken);
    }
}