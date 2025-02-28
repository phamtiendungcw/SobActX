using FluentValidation;

using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Products.Validators;

public class ProductAttributeValueDtoValidator : AbstractValidator<ProductAttributeValueDto>
{
    public ProductAttributeValueDtoValidator()
    {
        RuleFor(p => p.Attribute)
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Value)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");
    }
}