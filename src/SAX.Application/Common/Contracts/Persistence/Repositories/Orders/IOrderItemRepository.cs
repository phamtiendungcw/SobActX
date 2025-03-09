using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity OrderItem.
/// </summary>
public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    /// <summary>
    ///     Lấy danh sách các OrderItem theo OrderId một cách bất đồng bộ.
    /// </summary>
    /// <param name="orderId">Id của Order.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách OrderItem theo OrderId.</returns>
    Task<IReadOnlyList<OrderItem>> GetOrderItemsByOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}