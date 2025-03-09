using SAX.Domain.Entities.Customers;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Customers;

/// <summary>
///     Interface cho repository của entity Customer.
/// </summary>
public interface ICustomerRepository : IGenericRepository<Customer>
{
    /// <summary>
    ///     Lấy một khách hàng theo email một cách bất đồng bộ.
    /// </summary>
    /// <param name="email">Email của khách hàng.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Khách hàng nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken = default);
}