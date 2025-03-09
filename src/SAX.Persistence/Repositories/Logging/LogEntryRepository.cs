using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Logging;
using SAX.Domain;
using SAX.Domain.Entities.Logging;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Logging;

/// <summary>
///     Repository cho entity LogEntry.
/// </summary>
public class LogEntryRepository : GenericRepository<LogEntry>, ILogEntryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của LogEntryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public LogEntryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<LogEntry>> GetLogEntriesByLevelAsync(LogLevel logLevel, CancellationToken cancellationToken = default)
    {
        return await _dbContext.LogEntries.Where(log => log.LogLevel == logLevel && !log.IsDeleted && log.IsActive).ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<LogEntry>> GetLogEntriesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.LogEntries.Where(log => log.Timestamp >= startDate && log.Timestamp <= endDate && !log.IsDeleted && log.IsActive).ToListAsync(cancellationToken);
    }
}