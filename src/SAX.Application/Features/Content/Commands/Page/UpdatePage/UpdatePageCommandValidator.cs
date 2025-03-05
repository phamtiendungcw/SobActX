using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommand>
{
    public UpdatePageCommandValidator()
    {
        RuleFor(x => x.UpdatePageDto).NotNull().WithMessage("UpdatePageDto cannot be null.");
        RuleFor(x => x.UpdatePageDto!).SetValidator(new UpdatePageDtoValidator());
    }
}