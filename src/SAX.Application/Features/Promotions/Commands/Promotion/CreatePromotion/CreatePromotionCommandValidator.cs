using FluentValidation;

using SAX.Application.Features.Promotions.Validators;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
{
    public CreatePromotionCommandValidator()
    {
        RuleFor(p => p.CreatePromotionDto).NotNull().WithMessage("CreatePromotionDto is required.");
        RuleFor(x => x.CreatePromotionDto!).SetValidator(new CreatePromotionDtoValidator());
    }
}