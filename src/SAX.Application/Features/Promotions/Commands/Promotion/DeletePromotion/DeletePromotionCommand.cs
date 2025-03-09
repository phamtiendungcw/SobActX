using FluentResults;

using MediatR;

namespace SAX.Application.Features.Promotions.Commands.Promotion.DeletePromotion;

public class DeletePromotionCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}