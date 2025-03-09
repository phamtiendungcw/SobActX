namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi có xung đột resource (Conflict - 409), cố gắng tạo resource đã tồn tại.
/// </summary>
public class SaxConflictException : SaxCustomException
{
    public SaxConflictException(string message) : base(message)
    {
    }
}