using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;

public sealed class CreateSegmentCommandValidator : AbstractValidator<CreateSegmentCommand>
{
    public CreateSegmentCommandValidator()
    {
        RuleFor(x => x.CreateSegmentDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateSegmentDtoValidator());
    }
}