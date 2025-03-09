using SAX.Application.Features.Users.DTOs.User;
using SAX.Domain;

namespace SAX.Application.Features.Logging.DTOs;

public class LogEntryDto
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public LogLevel LogLevel { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public Guid? UserId { get; set; }
}