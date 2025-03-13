using FluentResults;

using MediatR;

namespace SAX.Application.Features.Orders.Commands.Order.DeleteOrder;

public abstract record DeleteOrderCommand(Guid Id) : IRequest<Result>;