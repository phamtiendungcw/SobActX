using SAX.Domain.Entities.Customers;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Customers;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    /// <summary>
    ///     Lấy khách hàng theo email (cho đăng nhập, kiểm tra tồn tại).
    /// </summary>
    Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các khách hàng đăng ký trong một khoảng thời gian cụ thể (cho báo cáo).
    /// </summary>
    Task<IReadOnlyList<Customer>> ListCustomersByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các khách hàng có nhiều đơn hàng nhất (cho phân tích khách hàng VIP).
    /// </summary>
    Task<IReadOnlyList<Customer>> ListTopCustomersByOrderCountAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm khách hàng theo tên hoặc email.
    /// </summary>
    Task<IReadOnlyList<Customer>> SearchCustomersAsync(string searchTerm, CancellationToken cancellationToken = default);
}