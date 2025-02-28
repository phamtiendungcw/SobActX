using FluentValidation;

using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Products.Validators;

public class ProductAttributeDtoValidator : AbstractValidator<ProductAttributeDto>
{
    public ProductAttributeDtoValidator()
    {
        RuleFor(p => p.AttributeName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}