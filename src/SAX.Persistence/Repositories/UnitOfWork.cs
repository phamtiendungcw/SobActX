using Microsoft.EntityFrameworkCore.Storage;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Domain.Entities;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SobActXDatabaseContext _dbContext;
    private readonly Dictionary<Type, object> _repositories; // Cache repositories
    private IDbContextTransaction _transaction; // Transaction management

    public UnitOfWork(SobActXDatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _repositories = new Dictionary<Type, object>();
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        if (!_repositories.ContainsKey(typeof(T))) _repositories.Add(typeof(T), new GenericRepository<T>(_dbContext));
        return (IGenericRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        try
        {
            _transaction?.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            DisposeTransaction();
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _transaction?.Rollback();
        }
        finally
        {
            DisposeTransaction();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void DisposeTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null!; // Reset transaction
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
            DisposeTransaction(); // Ensure transaction is disposed
        }
    }
}