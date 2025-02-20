namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Lớp exception cơ sở cho tất cả các custom exceptions trong ứng dụng.
/// </summary>
public abstract class CustomException : Exception
{
    protected CustomException(string message) : base(message)
    {
    }

    protected CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}