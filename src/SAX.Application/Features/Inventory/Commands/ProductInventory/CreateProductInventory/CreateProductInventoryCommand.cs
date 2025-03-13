using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public abstract record CreateProductInventoryCommand(CreateProductInventoryDto CreateProductInventoryDto) : IRequest<Result<Guid>>;