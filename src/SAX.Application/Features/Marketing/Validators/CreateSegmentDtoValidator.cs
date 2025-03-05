using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateSegmentDtoValidator : AbstractValidator<CreateSegmentDto>
{
    public CreateSegmentDtoValidator()
    {
        RuleFor(p => p.SegmentName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Criteria)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
    }
}