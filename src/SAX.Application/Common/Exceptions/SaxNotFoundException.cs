namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi một resource không được tìm thấy.
/// </summary>
public class SaxNotFoundException : SaxCustomException
{
    public SaxNotFoundException(string message) : base(message)
    {
    }

    public SaxNotFoundException(string name, object key) : base($"Entity \"{name}\" with Id: ({key}) was not found.")
    {
    }
}