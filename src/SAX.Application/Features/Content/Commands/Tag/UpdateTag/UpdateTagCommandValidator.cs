using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(x => x.UpdateTagDto).NotNull().WithMessage("UpdateTagDto cannot be null.");
        RuleFor(x => x.UpdateTagDto!).SetValidator(new UpdateTagDtoValidator());
    }
}