using System.Net;

namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception generic cho các lỗi API. Có thể dùng để wrap các exception khác.
/// </summary>
public class SaxApiException : SaxCustomException
{
    public SaxApiException(string message) : base(message)
    {
    }

    public SaxApiException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SaxApiException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; }
}