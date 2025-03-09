using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity ShoppingCart.
/// </summary>
public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
{
    /// <summary>
    ///     Lấy ShoppingCart theo CustomerId một cách bất đồng bộ.
    /// </summary>
    /// <param name="customerId">Id của Customer.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>ShoppingCart nếu tìm thấy, ngược lại trả về null.</returns>
    Task<ShoppingCart?> GetShoppingCartByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);
}