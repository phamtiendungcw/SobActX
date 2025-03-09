using SAX.Domain;
using SAX.Domain.Entities.Logging;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Logging;

/// <summary>
///     Interface cho repository của entity LogEntry.
/// </summary>
public interface ILogEntryRepository : IGenericRepository<LogEntry>
{
    /// <summary>
    ///     Lấy danh sách các LogEntry theo LogLevel một cách bất đồng bộ.
    /// </summary>
    /// <param name="logLevel">LogLevel để lọc.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách LogEntry theo LogLevel.</returns>
    Task<IReadOnlyList<LogEntry>> GetLogEntriesByLevelAsync(LogLevel logLevel, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các LogEntry trong một khoảng thời gian nhất định một cách bất đồng bộ.
    /// </summary>
    /// <param name="startDate">Thời gian bắt đầu.</param>
    /// <param name="endDate">Thời gian kết thúc.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách LogEntry trong khoảng thời gian.</returns>
    Task<IReadOnlyList<LogEntry>> GetLogEntriesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}