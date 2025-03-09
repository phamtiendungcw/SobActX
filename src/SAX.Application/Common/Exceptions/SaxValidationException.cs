using FluentValidation.Results;

namespace SAX.Application.Common.Exceptions;

/// <summary>
///     Exception được ném ra khi có lỗi validation.
/// </summary>
public class SaxValidationException : SaxCustomException
{
    private SaxValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public SaxValidationException(ValidationResult validationResult) : this(validationResult.Errors)
    {
    }

    public SaxValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}