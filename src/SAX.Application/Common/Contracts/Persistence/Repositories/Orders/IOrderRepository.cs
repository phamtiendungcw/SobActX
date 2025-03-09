using SAX.Domain;
using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IOrderRepository : IGenericRepository<Order>
{
    /// <summary>
    ///     Liệt kê các đơn hàng của một khách hàng cụ thể.
    /// </summary>
    Task<IReadOnlyList<Order>> GetOrdersByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các đơn hàng theo trạng thái đơn hàng.
    /// </summary>
    Task<IReadOnlyList<Order>> ListOrdersByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các đơn hàng được tạo trong một khoảng thời gian cụ thể (cho báo cáo bán hàng).
    /// </summary>
    Task<IReadOnlyList<Order>> ListOrdersByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy đơn hàng chi tiết bao gồm cả các order items (eager loading).
    /// </summary>
    Task<Order?> GetOrderDetailsWithItemsAsync(Guid orderId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các đơn hàng mới nhất (cho dashboard bán hàng).
    /// </summary>
    Task<IReadOnlyList<Order>> ListLatestOrdersAsync(int count, CancellationToken cancellationToken = default);
}