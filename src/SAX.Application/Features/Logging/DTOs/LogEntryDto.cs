using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Logging.DTOs;

public class LogEntryDto
{
    public Guid LogEntryId { get; set; }
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public UserDto? User { get; set; }
}