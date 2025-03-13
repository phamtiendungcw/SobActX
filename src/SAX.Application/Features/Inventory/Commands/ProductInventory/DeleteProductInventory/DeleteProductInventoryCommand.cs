using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.DeleteProductInventory;

public abstract record DeleteProductInventoryCommand(Guid Id) : IRequest<Result>;