using SAX.Domain.Entities.Customers;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Customers;

public interface IAddressRepository : IGenericRepository<Address>
{
    /// <summary>
    ///     Liệt kê các địa chỉ theo quốc gia (cho dropdown chọn quốc gia).
    /// </summary>
    Task<IReadOnlyList<Address>> ListAddressesByCountryAsync(string country, CancellationToken cancellationToken = default);
}