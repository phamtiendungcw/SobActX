namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi người dùng chưa được xác thực (Unauthorized - 401).
/// </summary>
public class SobActXUnauthorizedException : SobActXCustomException
{
    public SobActXUnauthorizedException(string message) : base(message)
    {
    }
}