using FluentResults;

using MediatR;

namespace SAX.Application.Features.Orders.Commands.Order.DeleteOrder;

public record DeleteOrderCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}