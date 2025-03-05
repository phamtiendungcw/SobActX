namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Lớp exception cơ sở cho tất cả các custom exceptions trong ứng dụng.
/// </summary>
public abstract class SobActXCustomException : Exception
{
    protected SobActXCustomException(string message) : base(message)
    {
    }

    protected SobActXCustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}