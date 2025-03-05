using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Category.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.CreateCategoryDto).NotNull().WithMessage("CreateCategoryDto cannot be null.");
        RuleFor(x => x.CreateCategoryDto!).SetValidator(new CreateCategoryDtoValidator());
    }
}