using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
{
    /// <summary>
    ///     Lấy shopping cart của một khách hàng cụ thể.
    /// </summary>
    Task<ShoppingCart?> GetShoppingCartByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy shopping cart chi tiết bao gồm cả các shopping cart items (eager loading).
    /// </summary>
    Task<ShoppingCart?> GetShoppingCartDetailsByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
}