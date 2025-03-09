namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Lớp exception cơ sở cho tất cả các custom exceptions trong ứng dụng.
/// </summary>
public abstract class SaxCustomException : Exception
{
    protected SaxCustomException(string message) : base(message)
    {
    }

    protected SaxCustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}