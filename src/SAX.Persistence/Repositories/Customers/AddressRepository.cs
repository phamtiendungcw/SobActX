using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Domain.Entities.Customers;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Customers;

/// <summary>
///     Repository cho entity Address.
/// </summary>
public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    /// <summary>
    ///     Khởi tạo một instance của AddressRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public AddressRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }
}