using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.DeleteProductInventory;

public class DeleteProductInventoryCommandHandler : IRequestHandler<DeleteProductInventoryCommand, Result>
{
    private readonly IProductInventoryRepository _productInventoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductInventoryCommandHandler(IProductInventoryRepository productInventoryRepository, IUnitOfWork unitOfWork)
    {
        _productInventoryRepository = productInventoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductInventoryCommand request, CancellationToken cancellationToken)
    {
        var productInventoryToDelete = await _unitOfWork.Repository<Domain.Entities.Inventory.ProductInventory>().GetByIdAsync(request.Id, cancellationToken);
        if (productInventoryToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.ProductInventory), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Inventory.ProductInventory>().DeleteAsync(productInventoryToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}