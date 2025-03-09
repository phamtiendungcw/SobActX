using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Domain.Entities.Customers;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Customers;

/// <summary>
///     Repository cho entity Customer.
/// </summary>
public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    /// <summary>
    ///     Khởi tạo một instance của CustomerRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public CustomerRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email && !c.IsDeleted && c.IsActive, cancellationToken);
    }
}