using FluentValidation;

using SAX.Application.Features.Promotions.Validators;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
{
    public UpdatePromotionCommandValidator()
    {
        RuleFor(p => p.UpdatePromotionDto).NotNull().WithMessage("UpdatePromotionDto is required.");
        RuleFor(x => x.UpdatePromotionDto!).SetValidator(new UpdatePromotionDtoValidator());
    }
}