using FluentResults;

using MediatR;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public abstract record UpdateOrderCommand(UpdateOrderDto UpdateOrderDto) : IRequest<Result>;