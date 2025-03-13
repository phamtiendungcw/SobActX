using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public abstract record UpdateProductInventoryCommand(UpdateProductInventoryDto UpdateProductInventoryDto) : IRequest<Result>;