using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IOrderStatusHistoryRepository : IGenericRepository<OrderStatusHistory>
{
    /// <summary>
    ///     Liệt kê lịch sử trạng thái đơn hàng của một đơn hàng cụ thể.
    /// </summary>
    Task<IReadOnlyList<OrderStatusHistory>> ListOrderStatusHistoryForOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}