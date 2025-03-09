using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

/// <summary>
///     Interface cho repository của entity PaymentTransaction.
/// </summary>
public interface IPaymentTransactionRepository : IGenericRepository<PaymentTransaction>
{
    /// <summary>
    ///     Lấy danh sách các PaymentTransaction theo OrderId một cách bất đồng bộ.
    /// </summary>
    /// <param name="orderId">Id của Order.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách PaymentTransaction theo OrderId.</returns>
    Task<IReadOnlyList<PaymentTransaction>> GetPaymentTransactionsByOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}