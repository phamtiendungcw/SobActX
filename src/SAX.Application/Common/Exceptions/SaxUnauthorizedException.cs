namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi người dùng chưa được xác thực (Unauthorized - 401).
/// </summary>
public class SaxUnauthorizedException : SaxCustomException
{
    public SaxUnauthorizedException(string message) : base(message)
    {
    }
}