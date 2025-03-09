using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, Result>
{
    private readonly IPromotionRepository _promotionRepository;

    public DeletePromotionCommandHandler(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task<Result> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotionToDelete = await _promotionRepository.GetByIdAsync(request.Id, cancellationToken);
        if (promotionToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Promotions.Promotion), request.Id).Message);

        await _promotionRepository.DeleteAsync(promotionToDelete, cancellationToken);

        return Result.Ok();
    }
}