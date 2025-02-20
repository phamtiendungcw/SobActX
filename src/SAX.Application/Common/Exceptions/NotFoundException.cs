namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi một resource không được tìm thấy.
/// </summary>
public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}