using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Tag.CreateTag;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.CreateTagDto).NotNull().WithMessage("CreateTagDto cannot be null.");
        RuleFor(x => x.CreateTagDto!).SetValidator(new CreateTagDtoValidator());
    }
}