using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity ShoppingCartItem.
/// </summary>
public interface IShoppingCartItemRepository : IGenericRepository<ShoppingCartItem>
{
    /// <summary>
    ///     Lấy danh sách các ShoppingCartItem theo ShoppingCartId một cách bất đồng bộ.
    /// </summary>
    /// <param name="shoppingCartId">Id của ShoppingCart.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách ShoppingCartItem theo ShoppingCartId.</returns>
    Task<IReadOnlyList<ShoppingCartItem>> GetShoppingCartItemsByCartAsync(Guid shoppingCartId, CancellationToken cancellationToken = default);
}