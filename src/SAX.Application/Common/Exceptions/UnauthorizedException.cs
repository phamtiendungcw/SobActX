namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi người dùng chưa được xác thực (Unauthorized - 401).
/// </summary>
public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}