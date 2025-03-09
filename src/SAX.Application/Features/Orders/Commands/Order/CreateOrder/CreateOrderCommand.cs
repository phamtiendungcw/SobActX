using FluentResults;

using MediatR;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Commands.Order.CreateOrder;

public record CreateOrderCommand : IRequest<Result<Guid>>
{
    public CreateOrderDto? CreateOrderDto { get; set; }
}