using FluentValidation;

using SAX.Application.Features.Products.Validators;

namespace SAX.Application.Features.Products.Commands.Product.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.CreateProductDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateProductDtoValidator());
    }
}