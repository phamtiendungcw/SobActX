using System.Collections;

using Microsoft.EntityFrameworkCore.Storage;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Domain.Entities;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SaxDbContext _context;
    private bool _disposed;
    private Hashtable? _repositories; // Lưu trữ các repository đã được khởi tạo
    private IDbContextTransaction? _transaction; // Quản lý transaction

    public UnitOfWork(SaxDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type]!;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null) await _transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null) await _transaction.RollbackAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            // Giải phóng managed resources (DbContext)
            _context.Dispose();
            if (_transaction != null) _transaction.Dispose();
        }

        _disposed = true;
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}