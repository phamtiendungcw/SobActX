namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi có xung đột resource (Conflict - 409), ví dụ: cố gắng tạo resource đã tồn tại.
/// </summary>
public class ConflictException : CustomException
{
    public ConflictException(string message) : base(message)
    {
    }
}