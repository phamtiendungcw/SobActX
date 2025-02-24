using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities.Logging;

public class LogEntry : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; } = string.Empty; // e.g., "Information", "Warning", "Error"
    public string Source { get; set; } = string.Empty; // Source of the log (e.g., ClassName, MethodName)
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; } // Optional exception details
    public int? UserId { get; set; } // Optional foreign key to User, if log entry is user-related
    public User? User { get; set; } // Navigation property
}