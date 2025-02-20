using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    /// <summary>
    ///     Liệt kê các order items thuộc về một đơn hàng cụ thể.
    /// </summary>
    Task<IReadOnlyList<OrderItem>> ListOrderItemsForOrderAsync(Guid orderId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy order item chi tiết bao gồm cả thông tin sản phẩm (eager loading).
    /// </summary>
    Task<OrderItem?> GetOrderItemDetailsWithProductAsync(Guid orderItemId, CancellationToken cancellationToken = default);
}