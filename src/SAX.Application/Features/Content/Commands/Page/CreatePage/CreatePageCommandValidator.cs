using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
{
    public CreatePageCommandValidator()
    {
        RuleFor(x => x.CreatePageDto).NotNull().WithMessage("CreatePageDto cannot be null.");
        RuleFor(x => x.CreatePageDto).SetValidator(new CreatePageDtoValidator());
    }
}