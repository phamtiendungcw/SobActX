using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.DeleteWarehouse;

public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, Result>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<Result> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouseToDelete = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
        if (warehouseToDelete != null)
        {
            await _warehouseRepository.DeleteAsync(warehouseToDelete, cancellationToken);
            return Result.Ok();
        }

        return Result.Fail($"Warehouse with id: {request.Id} not found.");
    }
}