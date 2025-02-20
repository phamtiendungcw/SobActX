using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IShoppingCartItemRepository : IGenericRepository<ShoppingCartItem>
{
    /// <summary>
    ///     Liệt kê các shopping cart items thuộc về một shopping cart cụ thể.
    /// </summary>
    Task<IReadOnlyList<ShoppingCartItem>> ListShoppingCartItemsForCartAsync(Guid shoppingCartId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy shopping cart item chi tiết bao gồm cả thông tin sản phẩm (eager loading).
    /// </summary>
    Task<ShoppingCartItem?> GetShoppingCartItemDetailsWithProductAsync(Guid shoppingCartItemId, CancellationToken cancellationToken = default);
}