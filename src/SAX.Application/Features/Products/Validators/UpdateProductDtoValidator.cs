using FluentValidation;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.Validators;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.ProductName)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
            .When(p => !string.IsNullOrEmpty(p.ProductName));

        RuleFor(p => p.Description)
            .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));

        RuleFor(p => p.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.UnitPrice.HasValue);

        RuleFor(p => p.ImageUrl)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.")
            .When(p => !string.IsNullOrEmpty(p.ImageUrl));

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.CategoryId.HasValue);
    }
}