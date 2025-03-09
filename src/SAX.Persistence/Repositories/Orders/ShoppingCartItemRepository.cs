using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity ShoppingCartItem.
/// </summary>
public class ShoppingCartItemRepository : GenericRepository<ShoppingCartItem>, IShoppingCartItemRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ShoppingCartItemRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ShoppingCartItemRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ShoppingCartItem>> GetShoppingCartItemsByCartAsync(Guid shoppingCartId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCartItems
            .Where(sci => sci.ShoppingCartId == shoppingCartId && !sci.IsDeleted && sci.IsActive)
            .ToListAsync(cancellationToken);
    }
}