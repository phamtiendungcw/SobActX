using SAX.Domain.Entities.Users;

namespace SAX.Domain.Entities.Logging;

public class LogEntry : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public LogLevel LogLevel { get; set; } // Enum {"Information", "Warning", "Error", "Debug"}
    public string Source { get; set; } = string.Empty; // Source of the log (e.g., ClassName, MethodName)
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; } // Optional exception details
    public Guid? UserId { get; set; } // Optional foreign key to User, if log entry is user-related
    public User? User { get; set; }
}