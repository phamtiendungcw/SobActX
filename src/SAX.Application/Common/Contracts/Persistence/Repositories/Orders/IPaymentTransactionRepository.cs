using SAX.Domain.Entities.Orders;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Orders;

public interface IPaymentTransactionRepository : IGenericRepository<PaymentTransaction>
{
    /// <summary>
    ///     Liệt kê các payment transactions thuộc về một đơn hàng cụ thể.
    /// </summary>
    Task<IReadOnlyList<PaymentTransaction>> ListPaymentTransactionsForOrderAsync(Guid orderId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy payment transaction theo payment gateway reference (transaction ID từ cổng thanh toán - cho mục đích kiểm tra
    ///     trùng lặp).
    /// </summary>
    Task<PaymentTransaction?> GetPaymentTransactionByGatewayReferenceAsync(string paymentGatewayReference, CancellationToken cancellationToken = default);
}