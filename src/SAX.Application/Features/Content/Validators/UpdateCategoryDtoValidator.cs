using FluentValidation;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Validators;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.CategoryName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.CategoryName));

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
            .When(p => p.Description != null);
    }
}