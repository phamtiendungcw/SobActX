using FluentResults;

using MediatR;

namespace SAX.Application.Features.Promotions.Commands.Promotion.DeletePromotion;

public abstract record DeletePromotionCommand(Guid Id) : IRequest<Result>;