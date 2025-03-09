using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity Order.
/// </summary>
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    /// <summary>
    ///     Khởi tạo một instance của OrderRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public OrderRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Order>> GetOrdersByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.CustomerId == customerId && !o.IsDeleted && o.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Order>> GetOrdersByStatusAsync(OrderStatus orderStatus, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.OrderStatus == orderStatus && !o.IsDeleted && o.IsActive)
            .ToListAsync(cancellationToken);
    }
}