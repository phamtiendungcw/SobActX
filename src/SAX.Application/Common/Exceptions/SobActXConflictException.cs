namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi có xung đột resource (Conflict - 409), cố gắng tạo resource đã tồn tại.
/// </summary>
public class SobActXConflictException : SobActXCustomException
{
    public SobActXConflictException(string message) : base(message)
    {
    }
}