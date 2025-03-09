using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Domain.Entities.Customers;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }

    public async Task<IReadOnlyList<Customer>> ListCustomersByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Customers
            .Where(c => c.RegistrationDate >= startDate && c.RegistrationDate <= endDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Customer>> ListTopCustomersByOrderCountAsync(int count, CancellationToken cancellationToken = default)
    {
        // Code mẫu này chỉ trả về latest customers, bạn cần tùy chỉnh để tính Top Customers by Order Count
        return await ListAllAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Customer>> SearchCustomersAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Customers
            .Where(c => c.FirstName.Contains(searchTerm) || c.LastName.Contains(searchTerm) || c.Email.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }
}