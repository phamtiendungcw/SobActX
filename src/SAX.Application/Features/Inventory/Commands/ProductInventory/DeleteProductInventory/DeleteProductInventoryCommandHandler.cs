using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.DeleteProductInventory;

public class DeleteProductInventoryCommandHandler : IRequestHandler<DeleteProductInventoryCommand, Result>
{
    private readonly IProductInventoryRepository _productInventoryRepository;

    public DeleteProductInventoryCommandHandler(IProductInventoryRepository productInventoryRepository)
    {
        _productInventoryRepository = productInventoryRepository;
    }

    public async Task<Result> Handle(DeleteProductInventoryCommand request, CancellationToken cancellationToken)
    {
        var productInventoryToDelete = await _productInventoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productInventoryToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.ProductInventory), request.Id).Message);
        await _productInventoryRepository.DeleteAsync(productInventoryToDelete, cancellationToken);

        return Result.Ok();
    }
}