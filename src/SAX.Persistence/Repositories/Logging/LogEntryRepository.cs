using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Logging;
using SAX.Domain.Entities.Logging;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Logging;

public class LogEntryRepository : GenericRepository<LogEntry>, ILogEntryRepository
{
    public LogEntryRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<LogEntry>> ListLogEntriesByLevelAsync(string logLevel, CancellationToken cancellationToken = default)
    {
        return await _dbContext.LogEntries
            .Where(le => le.LogLevel == logLevel)
            .Include(le => le.User) // Eager load User
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<LogEntry>> SearchLogEntriesAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbContext.LogEntries
            .Where(le => le.Message.Contains(searchTerm) || le.Exception.Contains(searchTerm) || le.Source.Contains(searchTerm))
            .Include(le => le.User) // Eager load User
            .ToListAsync(cancellationToken);
    }
}