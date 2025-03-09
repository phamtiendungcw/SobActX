using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity OrderStatusHistory.
/// </summary>
public interface IOrderStatusHistoryRepository : IGenericRepository<OrderStatusHistory>
{
    /// <summary>
    ///     Lấy danh sách các OrderStatusHistory theo OrderId một cách bất đồng bộ.
    /// </summary>
    /// <param name="orderId">Id của Order.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách OrderStatusHistory theo OrderId.</returns>
    Task<IReadOnlyList<OrderStatusHistory>> GetOrderStatusHistoriesByOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}