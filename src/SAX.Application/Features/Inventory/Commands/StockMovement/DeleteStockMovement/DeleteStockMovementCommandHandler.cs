using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.DeleteStockMovement;

public class DeleteStockMovementCommandHandler : IRequestHandler<DeleteStockMovementCommand, Result>
{
    private readonly IStockMovementRepository _stockMovementRepository;

    public DeleteStockMovementCommandHandler(IStockMovementRepository stockMovementRepository)
    {
        _stockMovementRepository = stockMovementRepository;
    }

    public async Task<Result> Handle(DeleteStockMovementCommand request, CancellationToken cancellationToken)
    {
        var stockMovementToDelete = await _stockMovementRepository.GetByIdAsync(request.Id, cancellationToken);
        if (stockMovementToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.StockMovement), request.Id).Message);
        await _stockMovementRepository.DeleteAsync(stockMovementToDelete, cancellationToken);

        return Result.Ok();
    }
}