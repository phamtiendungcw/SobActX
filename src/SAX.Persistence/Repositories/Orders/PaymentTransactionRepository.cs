using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

public class PaymentTransactionRepository : GenericRepository<PaymentTransaction>, IPaymentTransactionRepository
{
    public PaymentTransactionRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<PaymentTransaction>> ListPaymentTransactionsForOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PaymentTransactions
            .Where(pt => pt.OrderId == orderId)
            .ToListAsync(cancellationToken);
    }

    public async Task<PaymentTransaction?> GetPaymentTransactionByGatewayReferenceAsync(string paymentGatewayReference, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PaymentTransactions
            .FirstOrDefaultAsync(pt => pt.PaymentGatewayReference == paymentGatewayReference, cancellationToken);
    }
}