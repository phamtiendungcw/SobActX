namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi request từ client không hợp lệ (Bad Request - 400).
/// </summary>
public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message)
    {
    }
}