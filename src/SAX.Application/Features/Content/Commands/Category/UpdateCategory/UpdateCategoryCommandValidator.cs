using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.UpdateCategoryDto).NotNull().WithMessage("UpdateCategoryDto cannot be null.");
        RuleFor(x => x.UpdateCategoryDto!).SetValidator(new UpdateCategoryDtoValidator());
    }
}