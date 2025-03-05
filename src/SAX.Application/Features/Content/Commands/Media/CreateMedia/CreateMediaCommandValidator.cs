using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public class CreateMediaCommandValidator : AbstractValidator<CreateMediaCommand>
{
    public CreateMediaCommandValidator()
    {
        RuleFor(x => x.CreateMediaDto).NotNull().WithMessage("CreateMediaDto cannot be null.");
        RuleFor(x => x.CreateMediaDto).SetValidator(new CreateMediaDtoValidator());
    }
}