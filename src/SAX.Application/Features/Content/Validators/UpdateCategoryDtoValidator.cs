using FluentValidation;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Validators;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CategoryName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Description)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá 1000 ký tự.");
    }
}