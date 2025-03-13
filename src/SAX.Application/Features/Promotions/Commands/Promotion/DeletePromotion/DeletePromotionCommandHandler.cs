using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, Result>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePromotionCommandHandler(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork)
    {
        _promotionRepository = promotionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotionToDelete = await _unitOfWork.Repository<Domain.Entities.Promotions.Promotion>().GetByIdAsync(request.Id, cancellationToken);
        if (promotionToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Promotion), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Promotions.Promotion>().DeleteAsync(promotionToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}