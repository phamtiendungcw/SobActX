using SAX.Domain.Entities.Logging;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Logging;

public interface ILogEntryRepository : IGenericRepository<LogEntry>
{
    /// <summary>
    ///     Liệt kê các log entries theo mức độ log (ví dụ: Information, Warning, Error).
    /// </summary>
    Task<IReadOnlyList<LogEntry>> ListLogEntriesByLevelAsync(string logLevel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm log entries theo từ khóa trong message.
    /// </summary>
    Task<IReadOnlyList<LogEntry>> SearchLogEntriesAsync(string searchTerm, CancellationToken cancellationToken = default);

    ///// <summary>
    /////     Liệt kê các log entries trong một khoảng thời gian cụ thể (cho dashboard log).
    ///// </summary>
    //Task<IReadOnlyList<LogEntry>> ListLogEntriesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}