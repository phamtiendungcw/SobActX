using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public sealed class UpdateSegmentCommandValidator : AbstractValidator<UpdateSegmentCommand>
{
    public UpdateSegmentCommandValidator()
    {
        RuleFor(x => x.UpdateSegmentDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateSegmentDtoValidator());
    }
}