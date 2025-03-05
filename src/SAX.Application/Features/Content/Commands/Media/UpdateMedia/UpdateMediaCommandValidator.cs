using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public class UpdateMediaCommandValidator : AbstractValidator<UpdateMediaCommand>
{
    public UpdateMediaCommandValidator()
    {
        RuleFor(x => x.UpdateMediaDto).NotNull().WithMessage("UpdateMediaDto cannot be null.");
        RuleFor(x => x.UpdateMediaDto).SetValidator(new UpdateMediaDtoValidator());
    }
}