using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;

public class ShoppingCartItemRepository : GenericRepository<ShoppingCartItem>, IShoppingCartItemRepository
{
    public ShoppingCartItemRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<ShoppingCartItem>> ListShoppingCartItemsForCartAsync(Guid shoppingCartId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCartItems
            .Where(sci => sci.ShoppingCartId == shoppingCartId)
            .Include(sci => sci.Product) // Eager load Product
            .ToListAsync(cancellationToken);
    }

    public async Task<ShoppingCartItem?> GetShoppingCartItemDetailsWithProductAsync(Guid shoppingCartItemId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCartItems
            .Where(sci => sci.Id == shoppingCartItemId)
            .Include(sci => sci.Product) // Eager load Product
            .FirstOrDefaultAsync(cancellationToken);
    }
}