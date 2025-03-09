using FluentResults;

using MediatR;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public record UpdateOrderCommand : IRequest<Result>
{
    public UpdateOrderDto? UpdateOrderDto { get; set; }
}