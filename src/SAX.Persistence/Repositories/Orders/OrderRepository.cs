using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain;
using SAX.Domain.Entities.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Order>> GetOrdersByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.Customer) // Eager load Customer, ShippingAddress, BillingAddress
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListOrdersByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.OrderStatus == status)
            .Include(o => o.Customer) // Eager load Customer, ShippingAddress, BillingAddress
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListOrdersByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetOrderDetailsWithItemsAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(o => o.Id == orderId)
            .Include(o => o.Customer)        // Eager load Customer, ShippingAddress, BillingAddress, OrderItems
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product) // Eager load Product trong OrderItems
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListLatestOrdersAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .OrderByDescending(o => o.OrderDate)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}