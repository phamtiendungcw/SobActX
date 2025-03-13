using FluentResults;

using MediatR;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Commands.Order.CreateOrder;

public abstract record CreateOrderCommand(CreateOrderDto CreateOrderDto) : IRequest<Result<Guid>>;