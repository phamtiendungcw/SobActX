using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.DeleteProductInventory;

public record DeleteProductInventoryCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}