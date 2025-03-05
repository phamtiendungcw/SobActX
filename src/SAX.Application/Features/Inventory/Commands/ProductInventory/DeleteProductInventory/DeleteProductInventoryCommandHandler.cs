using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;

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
        if (productInventoryToDelete != null)
        {
            await _productInventoryRepository.DeleteAsync(productInventoryToDelete, cancellationToken);
            return Result.Ok();
        }

        return Result.Fail($"Product Inventory with id: {request.Id} not found.");
    }
}