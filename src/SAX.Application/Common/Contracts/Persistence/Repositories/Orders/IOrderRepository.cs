using SAX.Domain;
using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity Order.
/// </summary>
public interface IOrderRepository : IGenericRepository<Order>
{
    /// <summary>
    ///     Lấy danh sách các Order theo CustomerId một cách bất đồng bộ.
    /// </summary>
    /// <param name="customerId">Id của Customer.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Order theo CustomerId.</returns>
    Task<IReadOnlyList<Order>> GetOrdersByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các Order theo OrderStatus một cách bất đồng bộ.
    /// </summary>
    /// <param name="orderStatus">OrderStatus để lọc.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách Order theo OrderStatus.</returns>
    Task<IReadOnlyList<Order>> GetOrdersByStatusAsync(OrderStatus orderStatus, CancellationToken cancellationToken = default);
}