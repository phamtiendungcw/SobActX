namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception generic cho các lỗi API. Có thể dùng để wrap các exception khác.
/// </summary>
public class ApiException : CustomException
{
    public ApiException(string message) : base(message)
    {
    }

    public ApiException(string message, Exception innerException) : base(message, innerException)
    {
    }
}