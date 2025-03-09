using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public class UpdateSegmentCommandValidator : AbstractValidator<UpdateSegmentCommand>
{
    public UpdateSegmentCommandValidator()
    {
        RuleFor(x => x.UpdateSegmentDto).NotNull().WithMessage("UpdateSegmentDto is required.");
        RuleFor(x => x.UpdateSegmentDto!).SetValidator(new UpdateSegmentDtoValidator());
    }
}