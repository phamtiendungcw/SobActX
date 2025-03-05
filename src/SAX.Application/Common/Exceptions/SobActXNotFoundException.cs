namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi một resource không được tìm thấy.
/// </summary>
public class SobActXNotFoundException : SobActXCustomException
{
    public SobActXNotFoundException(string message) : base(message)
    {
    }

    public SobActXNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}