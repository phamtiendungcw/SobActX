using FluentValidation;

using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Products.Validators;

public class ProductBrandDtoValidator : AbstractValidator<ProductBrandDto>
{
    public ProductBrandDtoValidator()
    {
        RuleFor(p => p.BrandName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
    }
}