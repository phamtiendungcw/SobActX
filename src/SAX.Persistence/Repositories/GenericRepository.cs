using Ardalis.Specification.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Domain.Entities;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories;

public class GenericRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : BaseEntity
{
    protected readonly SaxDbContext _dbContext;

    public GenericRepository(SaxDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().AnyAsync(e => e.Id == id, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        if (entity != null) _dbContext.Set<T>().Remove(entity);
    }
}