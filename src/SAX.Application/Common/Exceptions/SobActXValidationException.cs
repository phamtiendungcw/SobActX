using FluentValidation.Results;

namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi có lỗi validation.
/// </summary>
public class SobActXValidationException : SobActXCustomException
{
    private SobActXValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public SobActXValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}