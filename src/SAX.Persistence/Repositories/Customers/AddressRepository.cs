using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Customers;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Domain.Entities.Customers;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Address>> ListAddressesByCountryAsync(string country, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Addresses
            .Where(a => a.Country == country)
            .ToListAsync(cancellationToken);
    }
}