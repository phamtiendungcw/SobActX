namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi người dùng đã xác thực nhưng không có quyền truy cập resource (Forbidden - 403).
/// </summary>
public class ForbiddenException : CustomException
{
    public ForbiddenException(string message) : base(message)
    {
    }
}