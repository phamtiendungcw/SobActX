using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateSegmentDtoValidator : AbstractValidator<CreateSegmentDto>
{
    public CreateSegmentDtoValidator()
    {
        RuleFor(p => p.SegmentName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Criteria)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}