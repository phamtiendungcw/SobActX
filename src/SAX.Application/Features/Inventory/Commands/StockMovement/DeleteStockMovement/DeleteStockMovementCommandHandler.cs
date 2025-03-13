using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.DeleteStockMovement;

public class DeleteStockMovementCommandHandler : IRequestHandler<DeleteStockMovementCommand, Result>
{
    private readonly IStockMovementRepository _stockMovementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockMovementCommandHandler(IStockMovementRepository stockMovementRepository, IUnitOfWork unitOfWork)
    {
        _stockMovementRepository = stockMovementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStockMovementCommand request, CancellationToken cancellationToken)
    {
        var stockMovementToDelete = await _unitOfWork.Repository<Domain.Entities.Inventory.StockMovement>().GetByIdAsync(request.Id, cancellationToken);
        if (stockMovementToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.StockMovement), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Inventory.StockMovement>().DeleteAsync(stockMovementToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}