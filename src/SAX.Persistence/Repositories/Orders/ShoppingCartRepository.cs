using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity ShoppingCart.
/// </summary>
public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
{
    /// <summary>
    ///     Khởi tạo một instance của ShoppingCartRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public ShoppingCartRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<ShoppingCart?> GetShoppingCartByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.ShoppingCarts.FirstOrDefaultAsync(sc => sc.CustomerId == customerId && !sc.IsDeleted && sc.IsActive, cancellationToken);
    }
}