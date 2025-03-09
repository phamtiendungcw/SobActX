using FluentValidation;

using SAX.Application.Features.Products.Validators;

namespace SAX.Application.Features.Products.Commands.Product.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.CreateProductDto).NotNull().WithMessage("CreateProductDto is required.");
        RuleFor(x => x.CreateProductDto!).SetValidator(new CreateProductDtoValidator());
    }
}