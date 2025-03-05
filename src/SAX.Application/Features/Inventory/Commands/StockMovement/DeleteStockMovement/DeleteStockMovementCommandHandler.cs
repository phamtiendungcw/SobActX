using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

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
        if (stockMovementToDelete != null)
        {
            await _stockMovementRepository.DeleteAsync(stockMovementToDelete, cancellationToken);
            return Result.Ok();
        }

        return Result.Fail($"Stock Movement with id: {request.Id} not found.");
    }
}