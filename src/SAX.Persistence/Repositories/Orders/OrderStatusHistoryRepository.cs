using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

public class OrderStatusHistoryRepository : GenericRepository<OrderStatusHistory>, IOrderStatusHistoryRepository
{
    public OrderStatusHistoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<OrderStatusHistory>> ListOrderStatusHistoryForOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.OrderStatusHistories
            .Where(osh => osh.OrderId == orderId)
            .ToListAsync(cancellationToken);
    }
}