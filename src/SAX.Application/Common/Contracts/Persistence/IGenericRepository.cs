using Ardalis.Specification;

using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

public interface IGenericRepository<T> : IRepositoryBase<T> where T : BaseEntity
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
}