namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception generic cho các lỗi API. Có thể dùng để wrap các exception khác.
/// </summary>
public class SobActXApiException : SobActXCustomException
{
    public SobActXApiException(string message) : base(message)
    {
    }

    public SobActXApiException(string message, Exception innerException) : base(message, innerException)
    {
    }
}