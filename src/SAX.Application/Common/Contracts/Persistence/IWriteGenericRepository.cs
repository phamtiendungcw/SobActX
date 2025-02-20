using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

public interface IWriteGenericRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
}