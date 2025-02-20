using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

public interface IReadGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<T> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
}