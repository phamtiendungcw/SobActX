using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Domain.Entities.Orders;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Orders;

/// <summary>
///     Repository cho entity PaymentTransaction.
/// </summary>
public class PaymentTransactionRepository : GenericRepository<PaymentTransaction>, IPaymentTransactionRepository
{
    /// <summary>
    ///     Khởi tạo một instance của PaymentTransactionRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public PaymentTransactionRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PaymentTransaction>> GetPaymentTransactionsByOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PaymentTransactions
            .Where(pt => pt.OrderId == orderId && !pt.IsDeleted && pt.IsActive)
            .ToListAsync(cancellationToken);
    }
}