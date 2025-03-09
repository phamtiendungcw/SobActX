using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

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
        if (warehouseToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.Warehouse), request.Id).Message);
        await _warehouseRepository.DeleteAsync(warehouseToDelete, cancellationToken);

        return Result.Ok();
    }
}