using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;

public class CreateSegmentCommandValidator : AbstractValidator<CreateSegmentCommand>
{
    public CreateSegmentCommandValidator()
    {
        RuleFor(x => x.CreateSegmentDto).NotNull().WithMessage("CreateSegmentDto is required.");
        RuleFor(x => x.CreateSegmentDto!).SetValidator(new CreateSegmentDtoValidator());
    }
}