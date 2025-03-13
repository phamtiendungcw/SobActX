using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.DeleteWarehouse;

public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, Result>
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouseToDelete = await _unitOfWork.Repository<Domain.Entities.Inventory.Warehouse>().GetByIdAsync(request.Id, cancellationToken);
        if (warehouseToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.Warehouse), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Inventory.Warehouse>().DeleteAsync(warehouseToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}