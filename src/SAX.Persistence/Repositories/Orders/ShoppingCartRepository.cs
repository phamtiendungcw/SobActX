using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Domain.Entities.Orders;

public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<ShoppingCart?> GetShoppingCartByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCarts
            .FirstOrDefaultAsync(sc => sc.CustomerId == customerId, cancellationToken);
    }

    public async Task<ShoppingCart?> GetShoppingCartDetailsByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCarts
            .Where(sc => sc.CustomerId == customerId)
            .Include(sc => sc.ShoppingCartItems) // Eager load ShoppingCartItems và Product
            .ThenInclude(sci => sci.Product)
            .FirstOrDefaultAsync(cancellationToken);
    }
}